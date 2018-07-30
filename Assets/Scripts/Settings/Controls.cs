using UnityEngine;
using System.Collections.Generic;

public static class InputManager {

    public enum playerEnum
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
    public static List<ControlScheme> playerControls = new List<ControlScheme>();
    
    public static bool GetButtonDown(playerEnum player, string button)
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

    public static string[] GetButtonNames(playerEnum player = 0)
    {
        ControlScheme playerControl = playerControls[(int)player];
        return playerControl.GetKeys();
    }

    public static float GetAxis(playerEnum player, string axis)
    {
        return Input.GetAxis(player.ToString() + axis);
    }

    public static bool GetButton(playerEnum player, string button)
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

    public static void SetControlScheme(playerEnum player, ControlScheme scheme)
    {
        playerControls[(int)player] = scheme;
    }

    public static void LoadControlSchemes(string platform)
    {
        controlsFilePath = Application.dataPath + string.Format("/Data/Controls/{0}/Controls.json", platform); 
        availableControls = FS.LoadData<List<ControlScheme>>(controlsFilePath);
    }
}