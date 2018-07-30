using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public enum Teams { team1, team2 };
    public static GameControl instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        } else
        {
            Destroy(this);
        }
    }


    void Init()
    {
        SetupGameManagers();
        InitControlSchemes();
    }

    void SetupGameManagers()
    {
        if (SettingsManager.instance == null)
        {
            gameObject.AddComponent<SettingsManager>();
        }

        if (AudioManager.instance == null)
        {
            gameObject.AddComponent<AudioManager>();
        }
    }

    void InitControlSchemes()
    {
        string platform;
#if UNITY_EDITOR_WIN
        platform = "Windows";
#elif UNITY_EDITOR_OSX
        platform = "OSX";
#elif UNITY_STANDALONE_OSX
        platform = "OSX";
#elif UNITY_STANDALONE_WIN
        platform = "Windows";
#endif
        InputManager.LoadControlSchemes(platform);
        InputManager.SetControlScheme(InputManager.PlayerEnum.playerOne, InputManager.availableControls[0]);
        InputManager.SetControlScheme(InputManager.PlayerEnum.playerTwo, InputManager.availableControls[0]);
        InputManager.SetControlScheme(InputManager.PlayerEnum.playerThree, InputManager.availableControls[0]);
        InputManager.SetControlScheme(InputManager.PlayerEnum.playerFour, InputManager.availableControls[0]);
    }

    void Update()
    {

    }
}
