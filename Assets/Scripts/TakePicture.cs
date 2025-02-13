using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TakePicture
{
    public RawImage imageDisplay; // 撮影した画像を表示するUI
    public UnityEvent<string> OnPhotoCaptured; // 画像が撮影されたときに呼び出すイベント

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

                OnPhotoCaptured.Invoke(path);

                // UIに画像を表示
                imageDisplay.texture = texture;
                Debug.Log($"画像パス: ${path}");
            }
        });

        if (permission == NativeCamera.Permission.Denied || permission == NativeCamera.Permission.ShouldAsk)
        {
            Debug.Log("カメラの使用許可が必要です。");
        }
    }
}
