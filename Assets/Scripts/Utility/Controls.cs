using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public static class InputManager {

    public enum playerEnum
    {
        playerOne = 0,
        playerTwo,
        playerThree,
        playerFour,
    };
    private static string controlsFilePath = "";
    public static List<ControlScheme> availableControls = new List<ControlScheme>();
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
        return playerControl.actions.Keys.ToArray();
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
        controlsFilePath = ""; // Set based on platform
        availableControls = FS.LoadData<List<ControlScheme>>(controlsFilePath, "ArrayOfControlScheme");
    }
}