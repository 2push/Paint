using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrushType { Pencil, SquareBrush }

[RequireComponent(typeof(MeshRenderer))]
public class Painter : MonoBehaviour
{
    public BrushType brushType;

    int brushSize;
    Renderer meshRenderer;
    Color color;
    Texture2D customTexture;
    delegate void BrushTypeHandler(Vector2 pos);
    Dictionary<BrushType, BrushTypeHandler> brushTypes;
    Vector2Int pixelPos;
    int offset_SquareBrush;
    Vector2Int sizeOfTexture;
    Color32[] squareBrushColors;
    Camera cam;

    void Awake()
    {      
        Init();
    }

    void Init()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        brushTypes = new Dictionary<BrushType, BrushTypeHandler>
        {
            { BrushType.Pencil, BrushTypeHandler_Pencil },
            { BrushType.SquareBrush, BrushTypeHandler_SquareBrush }
        };
        sizeOfTexture = new Vector2Int((int)meshRenderer.bounds.size.x, (int)meshRenderer.bounds.size.y);
        customTexture = new Texture2D(sizeOfTexture.x, sizeOfTexture.y);
        meshRenderer.material.mainTexture = customTexture;
        cam = Camera.main;
        ChangeBrushSize(0.1f);
    }

    private void OnEnable()
    {
        ColorSetter.instance.ColorChanged += ChangeDrawColor;
        BrushSizeSetter.instance.BrushSizeChanged += ChangeBrushSize;
        BrushTypeSetter.instance.BrushTypeChanged += ChangeBrushType;
    }

    private void OnDisable()
    {
        ColorSetter.instance.ColorChanged -= ChangeDrawColor;
        BrushSizeSetter.instance.BrushSizeChanged -= ChangeBrushSize;
        BrushTypeSetter.instance.BrushTypeChanged -= ChangeBrushType;
    }

    void ChangeBrushType(BrushType newBrushType) //is used by BrushTypeSetter
    {
        brushType = newBrushType;
    }

    void ChangeDrawColor(Color newColor) //is used by ColorSetter
    {
        color = newColor;
        FillSquareBrush();     
    }

    void ChangeBrushSize(float newSize) //is used by BrushSizeSetter
    {
        brushSize = (int)(newSize * 10);
        offset_SquareBrush = Mathf.RoundToInt(brushSize * 0.5f);
        FillSquareBrush();       
    }  

    void FillSquareBrush()
    {
        squareBrushColors = new Color32[brushSize * brushSize];
        for (int i = 0; i < brushSize * brushSize; i++)
        {
            squareBrushColors[i] = color;
        }
    }
    
    void Update()
    {
        if (!((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
            return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 5))
        {
            MeshCollider meshCollider = hit.collider as MeshCollider;
            if (meshCollider == null || meshCollider.sharedMesh == null)
                return;
            Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
            pixelPos = new Vector2Int((int)(pixelUV.x * customTexture.width), (int)(pixelUV.y * customTexture.height));
            brushTypes[brushType].Invoke(pixelPos); //method to set pixels color
            customTexture.Apply();
        }       
    }

    void BrushTypeHandler_Pencil(Vector2 pixel)
    {
        customTexture.SetPixel(pixelPos.x, pixelPos.y, color);
    }

    void BrushTypeHandler_SquareBrush(Vector2 pixel)
    {
        customTexture.SetPixels32((int)Mathf.Clamp(pixel.x - offset_SquareBrush, 0, sizeOfTexture.x-brushSize),
        (int)Mathf.Clamp(pixel.y - offset_SquareBrush, 0, sizeOfTexture.y - brushSize), brushSize, brushSize, squareBrushColors);
    }  

    public Texture2D GetTexture() //is used by to get the texture for a save
    {
        return customTexture;
    }
}