using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    [SerializeField]
    private float moveSpeed;

    protected override void Start()
    {
        base.Start();
        attack = player.attack;     //refer to Bullet.cs
    }

    void Update()
    {
        Move(moveSpeed);
        Resize(moveSpeed);
        DestroyMe(lifespan);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy" || c.tag == "Boss")
        {
            Enemy enemy = c.GetComponent<Enemy>();
            enemy.health -= DealDamage(attack, enemy.defense);
            Destroy(gameObject);
        }
    }
}