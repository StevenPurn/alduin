using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
	}
	
	void Update () {
		
	}
}
