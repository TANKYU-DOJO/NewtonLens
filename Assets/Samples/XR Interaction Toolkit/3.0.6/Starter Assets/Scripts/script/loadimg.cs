using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace
using NativeCameraNamespace;
using System.Text.RegularExpressions; // Ensure this line is correct

public class loadimg : MonoBehaviour
{
    public RawImage imageDisplay; // 撮影した画像を表示するUI
    public void Start()
    {
        // カメラの使用許可をリクエスト
        CapturePhoto();
    }
    // カメラを起動して写真を撮影するメソッド
    public void CapturePhoto()
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            if (path != null)
            {
                // 撮影された画像を読み込んでテクスチャとして表示
                Texture2D texture = NativeCamera.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("撮影された画像の読み込みに失敗しました。");
                    return;
                }

                // UIに画像を表示
                imageDisplay.texture = texture;
                Debug.Log("画像パス: " + path);
            }
        });

        if (permission == NativeCamera.Permission.Denied || permission == NativeCamera.Permission.ShouldAsk)
        {
            Debug.Log("カメラの使用許可が必要です。");
        
}}}
