using System.Collections.Generic;
using UnityEngine;

namespace Problem
{
    [System.Serializable]
    public class Parsed {
        [System.Serializable]
        public class RigidbodyDefinition {
            public string name; // オブジェクト名
            public string mass; // 質量
            public int x, y; // 初期位置
        }

        [System.Serializable]
        public class SpringDefinition {
            public List<string> connections; // ばねが繋いでいる物体の名前
            public string konstant; // ばね定数
        }

        [System.Serializable]
        public class StringDefinition {
            public List<string> connections; // 糸が繋いでいる物体の名前
            public string length; // 糸の長さ
        }

        public List<string> objects; // "壁"または"床"または"天井"
        public List<RigidbodyDefinition> rigidbodies; // 剛体
        public List<SpringDefinition> springs; // ばね
        public List<StringDefinition> strings; // 糸

        public Parsed(string jsonText) {
            JsonUtility.FromJsonOverwrite(jsonText, this);
        }
    }
}