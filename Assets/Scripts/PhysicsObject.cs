using UnityEngine;
using ProblemInterpreter;

public class PhysicsObject : MonoBehaviour
{
    //使うprefabを指定
    [SerializeField] GameObject ceilingPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void generateObject(Parsed parsed)
    {
        //各剛体について
        foreach (Parsed.RigidbodyDefinition rigidbody in parsed.rigidbodies)
        {
            //球体を生成
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //rigidbodyコンポーネントを追加
            sphere.AddComponent<Rigidbody>();
            //子にする
            sphere.transform.parent = this.transform;
            sphere.transform.localPosition = new Vector3(rigidbody.x/10, rigidbody.y/10, 0);
            sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sphere.name = rigidbody.name;
            
            //質量を設定(大=3, 中=2, 小=1)
            if (rigidbody.mass == "大")
            {
                sphere.GetComponent<Rigidbody>().mass = 3;
            }
            else if (rigidbody.mass == "中")
            {
                sphere.GetComponent<Rigidbody>().mass = 2;
            }
            else if (rigidbody.mass == "小")
            {
                sphere.GetComponent<Rigidbody>().mass = 1;
            }
        }
        Debug.Log(parsed.objects);
        Debug.Log(parsed.rigidbodies);
        //各環境オブジェクト(壁・床・天井)について
        foreach (string environment in parsed.objects)
        {
            //天井の場合
            if (environment == "天井")
            {
                Debug.Log("天井");
                GameObject ceiling = Instantiate(ceilingPrefab);
                ceiling.transform.parent = this.transform;
                ceiling.transform.localPosition = new Vector3(0,1,0);
                ceiling.name = "天井";
            }
        }
    }
}
