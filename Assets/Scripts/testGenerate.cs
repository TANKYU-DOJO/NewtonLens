using UnityEngine;
using ProblemInterpreter;

public class testGenerate : MonoBehaviour
{
    //テスト用にparsedを作る
    Parsed parsed;
    void Start()
    {
        //parsedを作る
        parsed = new Parsed("{\"objects\":[\"天井\"],\"rigidbodies\":[{\"name\":\"球1\",\"mass\":\"大\",\"x\":0,\"y\":2},{\"name\":\"球2\",\"mass\":\"中\",\"x\":0,\"y\":0}]}");
        //generateObjectを呼ぶ
        this.GetComponent<PhysicsObject>().generateObject(parsed);
    }

}
