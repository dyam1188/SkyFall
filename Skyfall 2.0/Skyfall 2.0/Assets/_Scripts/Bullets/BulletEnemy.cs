using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    [SerializeField]
    private float moveSpeed;
    private float lifespan = 1f;

    void Start()
    {

    }

    void Update()
    {
        Move(moveSpeed);
        Resize(moveSpeed);
        Destroy(lifespan);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag != "Enemy")
        {
            CalculateDamage(c);
            Destroy(gameObject);
        }
    }

    void CalculateDamage(Collider2D c)
    {
        Destroy(c.gameObject);
    }
}