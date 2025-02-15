using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClearObjectButton : MonoBehaviour
{
    Button button;
    [SerializeField] GameObject objectSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        objectSpawner.GetComponent<ObjectSpawner>().removeObject();
    }
}
