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
        
    }

    public void CreateCube (float X_size,float Y_size,float Z_size,Vector3 position){ {
        //get Cube object of child
        GameObject cube = this.transform.GetChild(0).gameObject;

        //get transoform of the object
        Transform transform = cube.transform;
        //resize the object to the given size
        transform.localScale = new Vector3(X_size,Y_size,Z_size);
        //set the position of the object on the floor
        transform.position = position + new Vector3(0,Y_size/2 ,0);
    }
}}

