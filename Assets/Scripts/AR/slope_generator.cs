using UnityEngine;

public class slope_generator : MonoBehaviour
{
	public float x = 1;
	public float y = 1;
	public float z = 1;
	void Start()
	{
	}


	public void CreateSlope(float X, float Y, float Z)
	{
		Vector3[] vertices = {
			new Vector3 (0, 0, 0),
			new Vector3 (X, 0, 0),
			new Vector3 (X, 0, Z),
			new Vector3 (0, 0, Z),
			new Vector3 (X, Y, Z),
			new Vector3 (0, Y, Z),
		};

		int[] triangles = {
			0, 2, 1, //face front
			0, 3, 2,
			4, 3, 2, //face top
			5, 3, 4,
			3,5,0,
			4,2,1,
			1,0,4,
			4,0,5
		};

		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.Optimize();
		mesh.RecalculateNormals();

		// applly to mesh collider
		MeshCollider meshCollider = GetComponent<MeshCollider>();
		meshCollider.sharedMesh = mesh;
	}
}