using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TakePictureButton : MonoBehaviour
{
    [SerializeField] GameObject objectSpawner;
    Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        objectSpawner.GetComponent<ObjectSpawner>().reload_scene();
    }
}
