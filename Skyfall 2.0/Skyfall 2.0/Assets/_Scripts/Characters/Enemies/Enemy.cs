using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent Enemy class
//controls all common enemy mechanics
public class Enemy : MonoBehaviour
{
    protected GameObject player;  //reference to player

    [Header("Stats")]

    public float health;
    //we are tracking attack in the respective bullet scripts
    public float defense;
    public float moveSpeed;
    public float attackSpeed;

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
        shootEnabled = true;
    }

    protected virtual void Update()
    {
        CheckState();
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

    //rotates to face player
    protected void LookAtPlayer()
    {
        transform.up = player.transform.position - transform.position;
    }

    protected virtual void Move(float speed)
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    protected void Shoot()
    {
        if (shootEnabled)
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            shootEnabled = false;
            StartCoroutine(ShootCooldown(1f / attackSpeed));
        }
    }

    IEnumerator ShootCooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        shootEnabled = true;
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

    //destroy itself if it leaves the camera
    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}