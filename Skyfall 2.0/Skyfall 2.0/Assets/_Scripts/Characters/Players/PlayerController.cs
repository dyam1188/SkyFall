using System.Collections;
using UnityEngine;

//controls the player
//attached to Game -> _Player
public class PlayerController : MonoBehaviour
{
    public Player player;
    public Bullet playerBullet;
    public GameObject bulletGameObject;

    [SerializeField]
    private Transform bulletSpawn;

    private int numLives;
    private int numSpecials;

    private int health;
    private int attack;
    private int defense;
    private int moveSpeed;
    private int shotDensity;

    public bool inputEnabled;
    private bool shootEnabled;

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

        inputEnabled = true;
    }

    void Start()
    {
        bulletGameObject.GetComponent<BulletController>().bullet = playerBullet;
        shootEnabled = true;
    }

    void Update()
    {
        if (inputEnabled)
        {
            Move();
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

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        shootEnabled = true;
    }

    void ShootBullet()
    {
        Instantiate(bulletGameObject, bulletSpawn.position, bulletSpawn.rotation);
    }
}