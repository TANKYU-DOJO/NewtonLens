using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using ProblemInterpreter;
using NativeCameraNamespace;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject PhysicsObject;
    private ARRaycastManager arRaycastManager;
    [SerializeField] GameObject ui_text;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] private bool spawnedFlag = false; // オブジェクトをすでにスポーンしたかどうか
    public ProblemInterpreter.Parsed parsed;
    
    //Prefabたち
    public GameObject ceilingPrefab;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject cubePrefab;
    public GameObject spherePrefab;

    void Start()
    {
        TakePhoto();
    }

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!spawnedFlag && Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (arRaycastManager.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    GameObject Physics_Object = Instantiate(PhysicsObject, hits[0].pose.position, Quaternion.identity);
                    spawnedFlag = true;
                    PhysicsObject physics_component = Physics_Object.GetComponent<PhysicsObject>();
                    
                    //prefabを設定
                    physics_component.ceilingPrefab = ceilingPrefab;
                    physics_component.wallPrefab = wallPrefab;
                    physics_component.floorPrefab = floorPrefab;
                    physics_component.cube=cubePrefab;
                    physics_component.sphere=spherePrefab;

                    //生成
                    physics_component.generateObject(parsed);
                }
            }
        }
    }

    //写真を取ってAIに送りつける。
    public  void TakePhoto()
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture(async (path) =>
        {
            if (path != null)
            {
                Debug.Log("Saved to: " + path);
                AI ai = new AI();
                var result = await ai.Ask(path);
                Debug.Log(result);
                parsed = new Parsed(result);

                Destroy(ui_text);
                
            }
        });
    }

    public void removeObject(){
        
        //find physics object and destroy
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PhysicsObject");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }

        spawnedFlag = false;
    }

    public void reload_scene(){
        //unity load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
