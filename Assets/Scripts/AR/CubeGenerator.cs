using UnityEngine;

/// <summary>
/// 与えられたサイズの立方体を床に接地するように生成する。
/// </summary>

public class CubeGenerator : MonoBehaviour
{
    public float x_size = 0.1f;
    public float y_size = 0.1f;
    public float z_size = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get Cube object of child
        GameObject cube = this.transform.GetChild(0).gameObject;

        //get transoform of the object
        Transform transform = cube.transform;
        //resize the object to the given size
        transform.localScale = new Vector3(x_size, y_size, z_size);
    }

    public void PlaceCube(Vector3 position)
    {
        //set the position of the object on the floor
        y_size = this.transform.GetChild(0).gameObject.transform.localScale.y;
        transform.position = position + new Vector3(0, y_size / 2, 0);
    }
}

