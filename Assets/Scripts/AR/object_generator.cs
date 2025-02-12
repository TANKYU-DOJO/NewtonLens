using UnityEngine;
using UnityEngine.UIElements;

public class object_generator : MonoBehaviour
{
    [SerializeField]GameObject string_prefab;
    [SerializeField]GameObject spring_prefab;
    [SerializeField]GameObject cube_prefab;
    [SerializeField]GameObject sphere_prefab;
    [SerializeField]GameObject ceiling_prefab;
    ///
    public void SpawnPendulum(Vector3 position,float line_length,bool isCube=false,float start_angle=0.0f){
        GameObject string_obj = Instantiate(string_prefab, position, Quaternion.identity);
        string_manager string_manager = string_obj.GetComponent<string_manager>();
        string_manager.string_length = line_length;
        string_manager.end_obj = isCube ? cube_prefab : sphere_prefab;
        string_manager.start_angle = start_angle;
        string_manager.start_obj = ceiling_prefab; 
    }
}
