using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    protected GameObject player;  //reference to player

    [Header("Stats")]

    public int health;
    public int attack;
    public int defense;
    public int moveSpeed;
    public int shotDensity;
    public int attackRange;

    [Space]

    [SerializeField]
    [Tooltip("Bullet reference")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("Where the bullet spawns")]
    protected Transform bulletSpawn;

    protected bool shootEnabled;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootEnabled = true;
    }

    protected virtual void Update()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (distance > attackRange)
        {
            Move();
        }

        else
        {
            Shoot(bullet);
        }
    }

    protected void Move()
    {
        transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
    }

    protected void Shoot(GameObject bullet)
    {
        if (shootEnabled)
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            shootEnabled = false;
            StartCoroutine(Delay(1f / shotDensity));
        }
    }

    IEnumerator Delay(float t)
    {
        yield return new WaitForSeconds(t);
        shootEnabled = true;
    }
}