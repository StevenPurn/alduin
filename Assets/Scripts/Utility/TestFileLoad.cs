using System.Collections.Generic;
using UnityEngine;

public class TestFileLoad : MonoBehaviour {

    public string filePath = "/Data/Controls/Windows/Controls.json";
    public ControlScheme scheme;

    // Use this for initialization
    void Start () {
        filePath = Application.dataPath + filePath;
        List<ControlScheme> list = FS.LoadData<List<ControlScheme>>(filePath, "", true);
        list.ForEach((item) => Debug.Log(item.ToString()));
    }
}
