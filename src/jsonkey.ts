// JSONのキーを変換する
export function RenameJsonKey(jsonText: string)
{
    const newKeys: { [key: string]: string } = {
        "不動オブジェクト": "objects",
        "剛体": "rigidbodies",
        "バネ": "springs",
        "糸": "strings",
        "物体の名前": "name",
        "質量": "mass",
        "X座標": "x",
        "Y座標": "y",
        "糸が繋いでいる物体の名前": "connections",
        "糸の長さ": "length",
        "バネが繋いでいる物体の名前": "connections",
        "バネ定数": "konstant",
    }

    let result = jsonText;
    const pattern = /"([^"]*?)"\s*?:/g
    result = result.replace(pattern, (_, key: string) => `"${newKeys[key]}":`);
    return result;
}