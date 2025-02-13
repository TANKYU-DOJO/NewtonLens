using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner_ : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] private bool spawnedFlag = false; // オブジェクトをすでにスポーンしたかどうか

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
                    Instantiate(spawnObject, hits[0].pose.position, Quaternion.identity);
                    spawnedFlag = true;
                }
            }
        }
    }
}
