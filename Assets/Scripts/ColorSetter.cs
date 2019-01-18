using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorSetter : MonoBehaviour
{
    public event Action<Color> ColorChanged;
    public static ColorSetter instance = null;
    Color color;

    private void Awake()
    {
        #region Singleton
        if (instance == null)         
            instance = this;        
        else if (instance == this)        
            Destroy(gameObject);
        #endregion      
    }

    public void ChangeRColor(float value)
    {
        color.r = value;
        color.a = 1;
        ColorChanged?.Invoke(color);
    }
    public void ChangeGColor(float value)
    {
        color.g = value;
        color.a = 1;
        ColorChanged?.Invoke(color);
    }
    public void ChangeBColor(float value)
    {
        color.b = value;
        color.a = 1;
        ColorChanged?.Invoke(color);
    }
}
