using UnityEngine;

public class Boss : MonoBehaviour {

    private float health = 100f;

    public void TakeDamage(float damage, PlayerController playerCon)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("killed by " + playerCon.player.ToString() + " on team " + playerCon.team.ToString());
        }
    }
}
