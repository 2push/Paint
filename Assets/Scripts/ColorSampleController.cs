using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorSampleController : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = Color.black;
    }

    private void OnEnable()
    {
        print(ColorSetter.instance);
        ColorSetter.instance.ColorChanged += ChangeDrawColor;
    }

    private void OnDisable()
    {
        ColorSetter.instance.ColorChanged -= ChangeDrawColor;
    }

    void ChangeDrawColor(Color newColor)
    {
        image.color = newColor;
    }
}