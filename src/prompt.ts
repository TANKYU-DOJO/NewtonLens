const text = `添付した物理の問題から、問題に登場する運動する物体を列挙しなさい。
物体の座標は具体的な数値で答えなさい。物体の質量は大、中、小で答えなさい。
壁、床、天井などのオブジェクトがある場合は、壁はx=0、床はy=0、天井はy=0として考えなさい。
また、問題に登場するバネ及び糸についても答えなさい。バネ及び糸が存在しなければ答えなくてよろしい。

以下のJSONスキーマを使うこと:
enum Mass {大, 中, 小}
Rigidbody = {
    '物体の名前': str,
    '質量': Mass,
    'X座標': int,
    'Y座標': int
}
enum Object {壁, 床, 天井, 斜面}
Spring = {
    'バネが繋いでいる物体の名前': list[str],
    'バネ定数': str
}
String = {
    '糸が繋いでいる物体の名前': list[str],
    '糸の長さ': str
}
Return = {
    '不動オブジェクト': list[Object],
    '剛体': list[Rigidbody],
    'バネ': list[Spring],
    '糸': list[String]
}`;

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