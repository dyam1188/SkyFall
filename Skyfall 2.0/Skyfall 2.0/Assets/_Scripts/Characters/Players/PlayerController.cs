using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the player
//attached to Game -> _Player
public class PlayerController : MonoBehaviour
{
    public Player player;
    public GameObject bullet;

    [SerializeField]
    private Transform bulletSpawn;

    private int numLives;
    private int numSpecials;

    public float health;
    public float attack;
    public float defense;

    private int moveSpeed;
    private int shotDensity;

    public bool inputEnabled;
    private bool shootEnabled;
    private bool isDead;

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        GetComponent<SpriteRenderer>().sprite = player.playerSprite;

        numLives = player.numLives;
        numSpecials = player.numSpecials;

        health = player.health;
        attack = player.attack;
        defense = player.defense;

        moveSpeed = player.moveSpeed;
        shotDensity = player.shotDensity;
    }

    void Start()
    {
        inputEnabled = true;
        shootEnabled = true;
        isDead = false;
    }

    void Update()
    {
        CheckState();

        if (inputEnabled)
        {
            Move();
        }

        if (shootEnabled)
        {
            Shoot();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector3.left * moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector3.right * moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate((Vector3.up * moveSpeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate((Vector3.down * moveSpeed) * Time.deltaTime);
        }

        //debugging purposes, will remove later
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }

    void Shoot()
    {
        if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space)) && shootEnabled)
        {
            ShootBullet();
            shootEnabled = false;
            StartCoroutine(Delay(1f / shotDensity));
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        shootEnabled = true;
    }

    void ShootBullet()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }

    void CheckState()
    {
        if (health <= 0)
        {
            numLives--;
        }

        if (numLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        inputEnabled = false;
        shootEnabled = false;
        isDead = true;
        Destroy(gameObject);
    }
}