using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControlScheme {

    public string name = "default";

    public Dictionary<string, KeyCode> actions = new Dictionary<string, KeyCode>()
    {
        { "shoot", KeyCode.Space },
        { "otherthing", KeyCode.Return }
    };

    public ControlScheme(string name, Dictionary<string, KeyCode> actions)
    {
        this.name = name;
        this.actions = actions;
    }

    public bool ContainsKey(string key)
    {
        return actions.ContainsKey(key);
    }

    public string[] GetKeys()
    {
        return actions.Keys.ToArray();
    }

    public KeyCode[] GetValues()
    {
        return actions.Values.ToArray();
    }

    public override string ToString()
    {
        string result = string.Format("name: {0}\n", name);
        foreach (KeyValuePair<string, KeyCode> entry in actions)
        {
            result += string.Format("{0}: {1}\n", entry.Key, entry.Value);
        }
        return result;
    }
}
