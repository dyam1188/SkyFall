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
    protected bool hasCoroutineStarted;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
        //shootEnabled = true;
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
            GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
            GetComponent<Collider2D>().enabled = false;
            if (!hasCoroutineStarted)
            {
                StartCoroutine(DropGold(gold));
            }
        }
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void TargetPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        float distance = Vector3.Distance(transform.position, playerPosition);

        LookAt();

        if (distance > attackRange)
        {
            Move(moveSpeed);
        }
        else
        {
            StartCoroutine(Shoot(3));
        }
    }

    //rotates to face player
    protected void LookAt()
    {
        transform.up = player.transform.position - transform.position;
    }

    void Move(float speed)
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    protected IEnumerator Shoot(int ammo)
    {
        if (shootEnabled)
        {
            for (int i = ammo; i > 0; i--)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                shootEnabled = false;
                yield return new WaitForSeconds(1f / shotDensity);
                shootEnabled = true;
            }
            shootEnabled = false;
        }
    }

    protected IEnumerator DropGold(int amount)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        hasCoroutineStarted = true;

        float duration = 1f;

        //don't ask why it works when i starts at 1 because idk why
        for (int i = 1; i < duration / Time.fixedDeltaTime; i++)
        {
            pc.gold += (amount / duration) * Time.fixedDeltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}