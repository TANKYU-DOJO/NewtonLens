const text = `添付した物理の問題から、問題に登場する運動する物体を列挙しなさい。
物体の初期位置は原点からの距離を10段階評価して答えなさい。
初速度が不明な場合は、"+"か"-"か"0"で答えなさい。
物体の質量は"大"、"中"、"小"で答えなさい。
壁、床、天井などの環境がある場合は、壁はx=0、床はy=0、天井はy=10として考えなさい。
また、問題に登場するバネ及び糸についても答えなさい。バネ及び糸が存在しなければ答えなくてよろしい。
バネの自然長、糸の長さは10段階評価して答えなさい。

以下のJSONスキーマを使うこと:
enum Mass {大, 中, 小}
enum Shape {直方体, 球体, 板, 台車}
Rigidbody = {
    "物体の名前": str,
    "形状": Shape,
    "質量": Mass,
    "初期位置のX座標": int,
    "初期位置のY座標": int,
    "初速度のx成分": str,
    "初速度のy成分": str
}
enum Environment {壁, 床, 天井, 斜面}
Spring = {
    "バネが繋いでいる物体及び環境の名前": list[str],
    "バネの自然長": int
}
String = {
    "糸が繋いでいる物体及び環境の名前": list[str],
    "糸の長さ": int
}
Return = {
    "環境": list[Environment],
    "剛体": list[Rigidbody],
    "バネ": list[Spring],
    "糸": list[String]
}`.replaceAll("\n", "\\n").replaceAll("\"", "\\\"");

export const prompt = (requestBody: string) => `{
"contents": [{
    "parts":[
        {"text": "${text}"},
        {
            "inline_data": ${requestBody}
        }
    ]
}],
"generationConfig": {"response_mime_type": "application/json" }
}`;