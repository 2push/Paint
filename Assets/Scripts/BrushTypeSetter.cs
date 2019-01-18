using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrushTypeSetter : MonoBehaviour
{
    public event Action<BrushType> BrushTypeChanged;
    public static BrushTypeSetter instance = null;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
        #endregion      
    }

    public void ChangeToPencil()
    {
        BrushTypeChanged?.Invoke(BrushType.Pencil);
    }

    public void ChangeToSquareBrush()
    {
        BrushTypeChanged?.Invoke(BrushType.SquareBrush);
    }
}
