using System.Text;
using System.Text.Json;
using System.Net;
using UnityEngine;

public class Test : MonoBehaviour
{
    string getJson()
    {
        byte[] imageBytes = await File.ReadAllBytesAsync("228.jpg");
        var base64string = Convert.ToBase64String(imageBytes);

        string text = @"
添付した物理の問題から、問題に登場する物体と働く力、初速度を列挙しなさい。物体の座標は具体的な数値で答えなさい。
また、問題に登場するバネについても答えなさい。バネが存在しなければ答えなくてよろしい。

以下のJSONスキーマを使うこと:
Force {'力の種類': str, 'x成分': str, 'y成分': str};
Object = {
    '物体の名前': str,
    '質量': int,
    'X座標': int,
    'Y座標': int,
    '働く力': list[Force],
    '初速度のx成分': str,
    '初速度のy成分': str
}
Spring = {
    'バネが繋いでいる物体の名前': list[str]
    'バネ定数': str
}
Return: list[Object], list[Spring]
".Replace("\n", "\\n");
        /*
        * 「物体の名前」はAIがオブジェクトを判別するのに必要だと思われる。あとデバッグが楽。
        */

        string json = """
{
\"contents": [{
    "parts":[
        { "text": "{{text}}"},
        {
            "inline_data": {
                "mime_type":"image/jpeg",
            "data": "{{base64string}}"
            }
        }
    ]
}],
"generationConfig": {"response_mime_type": "application/json" }
}
""";


        const string URL = @"https://script.google.com/macros/s/AKfycbzsc7T9AoFQQKl24u55QIu8D375duOSIvZ6yYIT2SeOQOZw2eaIluDP1R5EKW8YSp4/exec";
        var request = new HttpRequestMessage(HttpMethod.Post, URL);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Accept-Charset", "utf-8");
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var client = new HttpClient();
        var response = await client.PostAsync(URL, content);
        var body = await response.Content.ReadAsStringAsync();

        return body;
    }

    void Start()
    {

    }

    void Update() { }
}
