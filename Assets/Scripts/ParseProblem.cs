using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParseProblem {
    [System.Serializable]
    public class RigidbodyDefinition {
        public string name;
        public string mass;
        public int x, y;
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

    public List<string> objects;
    public List<RigidbodyDefinition> rigidbodies;
    public List<SpringDefinition> springs;
    public List<StringDefinition> strings;

    public ParseProblem(string jsonText) {
        JsonUtility.FromJsonOverwrite(jsonText, this);
    }
}