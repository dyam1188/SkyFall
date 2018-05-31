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

    public GameObject player;
    Transform target;
    public Transform myTransform;
    float attackRange;

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

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        bulletGameObject.GetComponent<BulletController>().bullet = enemyBullet;
        shootEnabled = true;
    }

    void Update()
    {
        Move();

        if (player != null)
        {
            target = player.GetComponent<Transform>();
        }

        float attackRange = Vector3.Distance(myTransform.position, target.position);

        //If too far from player, get in range
        if (attackRange > 20 && shootEnabled == false)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        //If in range of player stop and attack
        if (attackRange < 21)
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
        ShootBullet();
        shootEnabled = false;
        StartCoroutine(Delay(1f / shotDensity));
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