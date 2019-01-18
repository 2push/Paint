/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        
        mesh = new Mesh();
        vertices = new[] {
            new Vector3(0,0,0),
            new Vector3(1,1.414f,0),
            new Vector3(2,0,0)
        };
        mesh.vertices = vertices;

        triangles = new[] { 0, 1, 2 };
        mesh.triangles = triangles;
        meshFilter.mesh = mesh;
        
    }
    
    void Update()
    {
        
    }
}*/
