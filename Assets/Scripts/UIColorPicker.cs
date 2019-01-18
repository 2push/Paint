/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorPicker : MaskableGraphic
{
    [SerializeField]
    Texture m_Texture;

    // make it such that unity will trigger our ui element to redraw whenever we change the texture in the inspector
    public Texture texture
    {
        get
        {
            return m_Texture;
        }
        set
        {
            if (m_Texture == value)
                return;

            m_Texture = value;
            SetVerticesDirty();
            SetMaterialDirty();
        }
    }

    public override Texture mainTexture
    {
        get
        {
            return m_Texture ?? s_WhiteTexture;
        }
    }

    protected override void OnPopulateMesh(Mesh m)
    {
        //base.OnPopulateMesh(m);
        Vector3[] vertices = new[] {
            new Vector3(0,0,0),
            new Vector3(1,1.414f,0),
            new Vector3(2,0,0)
        };
        //m.vertices = vertices;
        int[] triangles = new[] { 0, 1, 2 };
        //m.triangles = triangles;
        
    }
}*/
