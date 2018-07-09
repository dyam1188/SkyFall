using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent Enemy class
public class Enemy : MonoBehaviour
{
    protected GameObject player;  //reference to player

    [Header("Stats")]

    public float health;
    //we are tracking attack in the respective bullet scripts
    public float defense;
    public float moveSpeed;
    public float shotDensity;
    public float attackRange;

    public int gold;

    [Header("Bullet Data")]

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
        TargetPlayer();
    }

    protected virtual void CheckState()
    {
        if (health <= 0)
        {
            player.GetComponent<PlayerController>().gold += gold;
            Destroy(gameObject);
        }
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected void TargetPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (distance > attackRange)
        {
            Move(moveSpeed);
        }
        else
        {
            Shoot(5);
        }

        LookAt();
    }

    void Move(float speed)
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    protected void Shoot(int ammo)
    {
        if (shootEnabled && ammo > 0)
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            ammo--;

            shootEnabled = false;
            StartCoroutine(ShootCooldown(1f / shotDensity));
        }
    }

    //rotates to face player
    protected void LookAt()
    {
        transform.up = player.transform.position - transform.position;
    }

    IEnumerator ShootCooldown(float t)
    {
        yield return new WaitForSeconds(t);
        shootEnabled = true;
    }
}