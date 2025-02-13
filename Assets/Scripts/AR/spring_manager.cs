
using UnityEngine;

public class spring : MonoBehaviour
{
    [SerializeField] GameObject start_point;
    [SerializeField] GameObject end_point;
    [SerializeField] LineRenderer lineRenderer;
    public float spring_constant = 1.0f;
    public GameObject end_obj;
    public GameObject start_obj;
    public float string_length = 1.0f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        init_spring();
        rb = end_point.GetComponent<Rigidbody>();
    }

    void init_spring()
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
        end_point.transform.position = start_point.transform.position - new Vector3(0, string_length, 0);
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

    void FixedUpdate()
    {
        rb.AddForce(-spring_constant * (end_point.transform.position - start_point.transform.position + new Vector3(0, string_length, 0)));
    }
}
