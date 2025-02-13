
using Unity.VisualScripting;
using UnityEngine;

public class spring_manager : MonoBehaviour
{
    public GameObject start_point;
    public GameObject end_point;
    private LineRenderer lineRenderer;
    public float spring_constant = 1.0f;
    public float string_length = 1.0f;
    private Rigidbody rb_s;
    private Rigidbody rb_e;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        init_spring();  
    }
    public void init_spring()
    {
        rb_e = end_point?.GetComponent<Rigidbody>();
        rb_s = start_point?.GetComponent<Rigidbody>();
        lineRenderer = this.AddComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }
    }

    void Update()
    {
        var positions = new Vector3[] { start_point.transform.position, end_point.transform.position, };
        lineRenderer?.SetPositions(positions);

    }

    void FixedUpdate()
    {
        rb_e?.AddForce(-spring_constant * (end_point.transform.position - start_point.transform.position)*(1-(string_length/(end_point.transform.position - start_point.transform.position).magnitude)));
        rb_s?.AddForce(spring_constant * (end_point.transform.position - start_point.transform.position)*(1-(string_length/(end_point.transform.position - start_point.transform.position).magnitude)));
    }
}
