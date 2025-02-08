using UnityEngine;

/// <summary>
/// 与えられたサイズの立方体を床に接地するように生成する。
/// </summary>
public class cube_generator : MonoBehaviour
{   
    public float x_size = 1;
    public float y_size = 1;
    public float z_size = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateCube(x_size, y_size, z_size);
    }

    private void CreateCube (float X,float Y,float Z) {
        //get Cube object of child
        GameObject cube = this.transform.GetChild(0).gameObject;

        //get transoform of the object
        Transform transform = cube.transform;
        //resize the object to the given size
        transform.localScale = new Vector3(X,Y,Z);
        //set the position of the object on the floor
        transform.position = new Vector3(0,transform.position.y + Y/2,0);
    }
}
