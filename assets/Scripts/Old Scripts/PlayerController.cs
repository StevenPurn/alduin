using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private const float MOVE_SPEED = 5.0f;
    private bool jumped = false;
    private bool shot = false;
    private bool canShoot = true;
    private Vector2 jumpVector = new Vector2(0, 350);
    private float xMov, yMov, xAim, yAim;
    private float shootDelay = 0.1f;

    public InputManager.PlayerEnum player;
    public PlayerController teammate;
    public Buffs buffs;
    public GameObject shotIndicator;
    public GameObject bulletPrefab;
    public Transform spawnLocation;
    public GameControl.Teams team;
    public float totalDamage = 0.0f;
    public float health = 10f;
    public int playersHit;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        buffs = GetComponent<Buffs>();
	}
	
	void Update () {
        GetInput();
	}

    private void FixedUpdate()
    {
        if (jumped)
        {
            jumped = false;
            rb.AddForce(jumpVector);
        }

        if (shot)
        {
            shot = false;
            GameObject go = Instantiate(bulletPrefab, spawnLocation.position, shotIndicator.transform.rotation);
            go.GetComponent<Bullet>().damage *= buffs.damage;
            go.GetComponent<Bullet>().originatingPlayer = this;
            go.transform.Translate(go.transform.forward);
        }

        transform.Translate(xMov, yMov, 0);
        var angle = new Vector3(0, 0, Mathf.Atan2(xAim, yAim) * 180 / Mathf.PI);
        shotIndicator.transform.eulerAngles = angle;
    }

    private bool CheckGrounded()
    {
        Vector2 rayPosition = new Vector2(transform.position.x, transform.position.y - 0.47f);
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.down, 0.03f);
        return hit != false;
    }

    private void GetInput()
    {

        if (InputManager.GetButtonDown(player, "SwitchWeapons"))
        {
            Debug.Log(player.ToString() + " changed weapons");
        }

        if(InputManager.GetButton(player, "shoot"))
        {
            if (canShoot)
            {
                canShoot = false;
                shot = true;
                Invoke("SetCanShoot", shootDelay);
            }
        }
        else
        {
            shot = false;
        }

        xMov = InputManager.GetAxis(player, "HorL") * MOVE_SPEED * buffs.speed * Time.deltaTime;
        yMov = -InputManager.GetAxis(player, "VerL") * MOVE_SPEED * buffs.speed * Time.deltaTime;
        xAim = -InputManager.GetAxis(player, "HorR") * MOVE_SPEED * Time.deltaTime;
        yAim = -InputManager.GetAxis(player, "VerR") * MOVE_SPEED * Time.deltaTime;
    }

    private void SetCanShoot()
    {
        canShoot = true;
    }

    public void HitPlayer()
    {
        playersHit += 1;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Debug.Log("Died");
        }
    }

    public void RecordDamage(float damage)
    {
        totalDamage += damage;
    }
}
