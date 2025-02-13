using Unity.Mathematics;
using UnityEditor; // Remove this line if not needed
using UnityEngine;

public class string_manager : MonoBehaviour
{
    [SerializeField] GameObject start_point;
    [SerializeField] GameObject end_point;
    [SerializeField] LineRenderer lineRenderer;
    public GameObject end_obj;
    public GameObject start_obj;
    public float string_length = 1.0f;
    // 初期位置(角度)
    public float start_angle = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject start = null;
        // Instantiate the start and end objects
        var end = Instantiate(end_obj, end_point.transform.position, Quaternion.identity);
        if (start_obj != null)
        {
            start = Instantiate(start_obj, start_point.transform.position, Quaternion.identity);
            //start_pointの子にする
            start.transform.parent = start_point.transform;
        }

        end.transform.parent = end_point.transform;

        //set the string length
        end_point.GetComponent<HingeJoint>().anchor = new Vector3(0, string_length, 0);

        //set the string angle
        end_point.transform.localPosition = new Vector3(0, -string_length * math.cos(start_angle), string_length * math.sin(start_angle));

        try
        {
            //endの子のすべてのRigidbodyを取得してisKinematicをtrueにする
            foreach (Rigidbody rb in end.GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = true;

                //log
                Debug.Log("Rigidbody is attached to the end object");
            }
        }
        catch (System.Exception)
        {
            Debug.Log("Rigidbody is not attached to the end object");
        }
    }

    void Update()
    {
        var positions = new Vector3[] { start_point.transform.position, end_point.transform.position, };
        lineRenderer?.SetPositions(positions);
    }
}
