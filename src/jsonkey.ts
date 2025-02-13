// JSONのキーを変換する
export function RenameJsonKey(jsonText: string)
{
    const newKeys: { [key: string]: string } = {
        "環境": "environments",
        "剛体": "rigidbodies",
        "バネ": "springs",
        "糸": "strings",
        "物体の名前": "name",
        "質量": "mass",
        "形状": "shape",
        "初期位置のX座標": "x",
        "初期位置のY座標": "y",
        "初速度のx成分": "vx",
        "初速度のy成分": "vy",
        "糸が繋いでいる物体の名前": "connections",
        "糸の長さ": "length",
        "バネが繋いでいる物体の名前": "connections",
        "バネ定数": "konstant",
        "バネの自然長": "length",
    }

    let result = jsonText;
    const pattern = /"([^"]*?)"\s*?:/g
    result = result.replace(pattern, (_, key: string) => `"${newKeys[key]}":`);
    return result;
}