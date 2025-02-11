using System.IO;
using UnityEditor.PackageManager;
using UnityEngine;

public class Gemini
{
    public static void Ask(string imagePath) {
        string mimeType = $"image/{Path.GetExtension(imagePath).TrimStart('.')}";
        
    }
}
