using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

    public enum Teams { team1, team2 };
    public static SettingsManager instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else
        {
            Destroy(this);
        }
    }

    void Init()
    {

    }
	
	void Update () {
		
	}
}
