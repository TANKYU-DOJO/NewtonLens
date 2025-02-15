using UnityEngine;
using ProblemInterpreter;
using Unity.VisualScripting;

public class PhysicsObject : MonoBehaviour
{
    //使うprefab
    public GameObject ceilingPrefab;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject cube;
    public GameObject sphere;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void generateObject(Parsed parsed)
    {
        //各剛体について
        foreach (Parsed.RigidbodyDefinition rigidbody in parsed.rigidbodies)
        {   
            GameObject obj = null;
            //形状による分岐
            if (rigidbody.shape == "球体")
            {
                //球体を生成
                obj = Instantiate(sphere);
            }
            else if (rigidbody.shape == "直方体")
            {
                //直方体を生成
                obj = Instantiate(cube);
            }else if (rigidbody.shape=="台車"){
                //台車を生成
                obj = Instantiate(cube);
            }
            //子にする
            obj.transform.parent = this.transform;
            obj.transform.localPosition = new Vector3(rigidbody.x/10, rigidbody.y/10 + 0.1f, 0);
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            obj.name = rigidbody.name;
            
            //質量を設定(大=3, 中=2, 小=1)
            if (rigidbody.mass == "大")
            {
                obj.GetComponent<Rigidbody>().mass = 3;
            }
            else if (rigidbody.mass == "中")
            {
                obj.GetComponent<Rigidbody>().mass = 2;
            }
            else if (rigidbody.mass == "小")
            {
                obj.GetComponent<Rigidbody>().mass = 1;
            }

            //初速度を設定
            float vx = 0;
            float vy = 0;

            //x軸
            if (rigidbody.vx != "0")
            {
                if(rigidbody.vx=="+"){
                    vx = 0.9f;
                }
                if(rigidbody.vx=="-"){
                    vx = -0.9f;
                }
            }
            //y軸
            if (rigidbody.vy != "0")
            {
                if(rigidbody.vy=="+"){
                    vy = 2.0f;
                }
                if(rigidbody.vy=="-"){
                    vy = -1.0f;
                }
            }
            obj.GetComponent<Rigidbody>().linearVelocity = new Vector3(vx, vy, 0);

            //摩擦をなくす
            obj.GetComponent<Collider>().material.dynamicFriction = 0;
            obj.GetComponent<Collider>().material.staticFriction = 0;

            //マテリアルの設定
            obj.GetComponent<Renderer>().material.color = Color.white;
        }
        Debug.Log(parsed.environments);
        Debug.Log(parsed.rigidbodies);
        //各環境オブジェクト(壁・床・天井)について
        foreach (string environment in parsed.environments)
        {   
            Debug.Log(environment);
            //天井の場合
            if (environment == "天井")
            {
                Debug.Log("天井");
                GameObject ceiling = Instantiate(ceilingPrefab);
                ceiling.transform.parent = this.transform;
                ceiling.transform.localPosition = new Vector3(0,1,0);
                ceiling.name = "天井";
            }

            //壁の場合
            else if (environment == "壁")
            {
                Debug.Log("壁");
                GameObject wall = Instantiate(wallPrefab);
                wall.transform.parent = this.transform;
                wall.transform.localPosition = new Vector3(-0.1f,0,0);
                wall.name = "壁"; 
            }
        }
            //床の場合
            
        Debug.Log("床");
        GameObject floor = Instantiate(floorPrefab);
        floor.transform.parent = this.transform;
        floor.transform.localPosition = new Vector3(0,0,0);
        floor.name = "床";
        

        //ばねの処理
        foreach (Parsed.SpringDefinition spring in parsed.springs)
        {
            //sptirng_managerの追加
            spring_manager spring_Manager = this.AddComponent<spring_manager>();
            //ばね定数・自然長を設定
            spring_Manager.spring_constant = 10;
            spring_Manager.string_length = float.Parse(spring.length)/10;
            //ばねの始点・終点を設定
            spring_Manager.start_point = GameObject.Find(spring.connections[0]);
            spring_Manager.end_point = GameObject.Find(spring.connections[1]);

            //spring_managerの初期化
            spring_Manager.init_spring();
        }

        //ばねの処理
        foreach (Parsed.StringDefinition String in parsed.strings)
        {
            //sptirng_managerの追加
            spring_manager spring_Manager = this.AddComponent<spring_manager>();
            //ばね定数・自然長を設定
            spring_Manager.spring_constant = 9999;
            spring_Manager.string_length = float.Parse(String.length)/10;
            //ばねの始点・終点を設定
            spring_Manager.start_point = GameObject.Find(String.connections[0]);
            spring_Manager.end_point = GameObject.Find(String.connections[1]);

            //spring_managerの初期化
            spring_Manager.init_spring();
        }
    }
}
