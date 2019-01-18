using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrushSizeSetter : MonoBehaviour
{
    public event Action<float> BrushSizeChanged;
    public static BrushSizeSetter instance = null;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
        #endregion      
    }

    public void ChangeBrushSize(float value)
    {
        BrushSizeChanged?.Invoke(value);
    }
}
