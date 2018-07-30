using UnityEngine;
using System.Collections.Generic;

public static class InputManager {

    public enum PlayerEnum
    {
        playerOne = 0,
        playerTwo,
        playerThree,
        playerFour,
    };
    private static string controlsFilePath;
    // All control schemes loaded from the file
    public static List<ControlScheme> availableControls = new List<ControlScheme>();
    // Control schemes in use for each player 0-3
    public static ControlScheme[] playerControls = new ControlScheme[4];
    
    public static bool GetButtonDown(PlayerEnum player, string button)
    {
        ControlScheme playerControl = playerControls[(int)player];
        if (playerControl.ContainsKey(button))
        {
            return Input.GetKeyDown(playerControl.actions[button]);
        } else {
            Debug.LogWarning(button + " button not found");
            return false;
        }
    }

    public static string[] GetButtonNames(PlayerEnum player = 0)
    {
        ControlScheme playerControl = playerControls[(int)player];
        return playerControl.GetKeys();
    }

    public static float GetAxis(PlayerEnum player, string axis)
    {
        string axisName;
#if UNITY_EDITOR_WIN
        axisName = player.ToString() + axis + "Win";
#elif UNITY_EDITOR_OSX
        axisName = player.ToString() + axis + "OSX";
#elif UNITY_STANDALONE_OSX
        axisName = player.ToString() + axis + "OSX";
#elif UNITY_STANDALONE_WIN
        axisName = player.ToString() + axis + "Win";
#endif
        return Input.GetAxis(axisName);
    }

    public static bool GetButton(PlayerEnum player, string button)
    {
        ControlScheme playerControl = playerControls[(int)player];
        if (playerControl.ContainsKey(button))
        {
            return Input.GetKey(playerControl.actions[button]);
        } else {
            Debug.LogWarning(button + " button not found");
            return false;
        }
    }

    public static void SetControlScheme(PlayerEnum player, ControlScheme scheme)
    {
        playerControls[(int)player] = scheme;
    }

    public static void SaveControlScheme(ControlScheme scheme)
    {
        // Append the new control scheme to the json file
    }

    public static void LoadControlSchemes(string platform)
    {
        controlsFilePath = Application.dataPath + string.Format("/Data/Controls/{0}/Controls.json", platform); 
        availableControls = FS.LoadData<List<ControlScheme>>(controlsFilePath);
    }
}