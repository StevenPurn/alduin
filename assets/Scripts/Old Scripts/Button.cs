﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameControl.Teams team;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerCon = collision.GetComponent<PlayerController>();
        if (playerCon != null)
        {   
            if (playerCon.team == team)
            {
                playerCon.teammate.GetComponent<Buffs>().damage = 1.2f;
            }
            else
            {
                Debug.Log("team doesn't match");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (collision.GetComponent<PlayerController>().team == team)
            {
                Debug.Log("button inactive");
            }
            else
            {
                Debug.Log("team doesn't match");
            }
        }
    }
}
