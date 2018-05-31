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
        bulletGameObject.GetComponent<BulletController>().bullet = enemyBullet;
        shootEnabled = true;
    }

    void Update()
    {
        if (shootEnabled)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        ShootBullet();
        shootEnabled = false;
        StartCoroutine(Delay(1f / shotDensity));
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