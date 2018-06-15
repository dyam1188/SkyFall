using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent Enemy class
public class Enemy : MonoBehaviour
{
    protected GameObject player;  //reference to player

    [Header("Stats")]

    public float health;
    //we are tracking attack in the bullets now
    public float defense;
    public int moveSpeed;
    public int shotDensity;
    public int attackRange;

    [Space]

    [SerializeField]
    [Tooltip("Bullet reference")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("Where the bullet spawns")]
    private Transform bulletSpawn;

    protected bool shootEnabled;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
        shootEnabled = true;
    }

    protected virtual void Update()
    {
        CheckState();
        FindPlayer();
    }

    void CheckState()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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