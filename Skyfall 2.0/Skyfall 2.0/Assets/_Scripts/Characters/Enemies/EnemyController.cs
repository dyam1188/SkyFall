using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public EnemyCommon enemy;
    public Bullet enemyBullet;
    public GameObject bulletGameObject;

    [SerializeField]
    private Transform bulletSpawn;

    private int health;
    private int attack;
    private int defense;
    private int moveSpeed;
    private int shotDensity;

    private bool shootEnabled;

    private GameObject player;
    private Vector3 playerPosition;

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
        health = enemy.health;
        attack = enemy.attack;
        defense = enemy.defense;

        moveSpeed = enemy.moveSpeed;
        shotDensity = enemy.shotDensity;
    }

    void Start()
    {
        bulletGameObject.GetComponent<EnemyBulletController>().bullet = enemyBullet;
        shootEnabled = true;

        player = GameObject.FindWithTag("Player");
        //Debug.Log(player.name);
    }

    void Update()
    {
        GetPlayerDistance();
    }

    void GetPlayerDistance()
    {
        playerPosition = player.transform.position;
        float attackRange = Vector3.Distance(transform.position, playerPosition);

        //If too far from player, get in range
        if (attackRange > 5)
        {
            //transform.LookAt(playerPosition);
            Move();
        }

        //If in range of player stop and attack
        else
        {
            Shoot();
        }
    }

    void Move()
    {
        transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
    }

    void Shoot()
    {
        if (shootEnabled)
        {
            ShootBullet();
            shootEnabled = false;
            StartCoroutine(Delay(1f / shotDensity));
        }
    }

    void ShootBullet()
    {
        Instantiate(bulletGameObject, bulletSpawn.position, bulletSpawn.rotation);
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        shootEnabled = true;
    }
}