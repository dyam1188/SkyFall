using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the player
//attached to Game -> _Player
public class PlayerController : MonoBehaviour
{
    public Player player;
    private GameObject bullet;
    public Color uiColor;

    [SerializeField]
    private Transform bulletSpawn;

    private int numLives;
    public int numSpecials;

    public float currentHealth;
    public float maxHealth;
    public float attack;
    public float defense;

    private int moveSpeed;
    private float specialCooldown;

    public bool inputEnabled;
    private bool shootEnabled;
    private bool specialEnabled;

    public int gold;

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        GetComponent<SpriteRenderer>().sprite = player.sprite;
        bullet = player.bullet;
        uiColor = player.uiColor;

        numLives = player.numLives;
        numSpecials = player.numSpecials;

        maxHealth = player.maxHealth;
        currentHealth = maxHealth;
        attack = player.attack;
        defense = player.defense;

        moveSpeed = player.moveSpeed;
        specialCooldown = player.specialCooldown;
    }

    void Start()
    {
        inputEnabled = true;
        shootEnabled = true;
        specialEnabled = true;
    }

    void Update()
    {
        CheckState();
        ClampStats();

        if (inputEnabled)
        {
            Move();
        }

        if (shootEnabled)
        {
            ShootDefault();
            ShootSpecial();
        }
    }

    void CheckState()
    {
        if (currentHealth <= 0)
        {
            numLives--;
            currentHealth = maxHealth;
        }

        if (numLives <= 0)
        {
            Die();
        }
    }

    void ClampStats()
    {
        numLives = Mathf.Clamp(numLives, 0, Player.maxLives);
        numSpecials = Mathf.Clamp(numSpecials, 0, Player.maxSpecials);
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

    void ShootDefault()
    {
        if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space)) && shootEnabled)
        {
            ShootBullet();
            shootEnabled = false;
            StartCoroutine(ShootCooldown(1f / player.shotDensity));
        }
    }

    void ShootSpecial()
    {
        if (Input.GetKeyDown(KeyCode.Z) && numSpecials > 0 && specialEnabled) {
            //shoot special
            numSpecials--;
            inputEnabled = false;
            shootEnabled = false;
            specialEnabled = false;
            StartCoroutine(SpecialCooldown(specialCooldown));
        }
    }

    IEnumerator ShootCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        shootEnabled = true;
    }

    IEnumerator SpecialCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        inputEnabled = true;
        shootEnabled = true;
        specialEnabled = true;
    }

    void ShootBullet()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }

    void Die()
    {
        inputEnabled = false;
        shootEnabled = false;
        Destroy(gameObject);
    }
}