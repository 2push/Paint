using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureSaver : MonoBehaviour
{
    public void SavePicture()
    {
        Texture2D texture = FindObjectOfType<Painter>().GetTexture(); //there is only one object to draw on, so I'm free to do this
        string fullPath = System.IO.Directory.GetCurrentDirectory();
        System.DateTime date = System.DateTime.Now;
        string fileName = "DrawingTexture.png";
        if (!System.IO.Directory.Exists(fullPath))
            System.IO.Directory.CreateDirectory(fullPath);
        var bytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath + fileName, bytes);
        print("Texture was successfully saved");
    }
}
