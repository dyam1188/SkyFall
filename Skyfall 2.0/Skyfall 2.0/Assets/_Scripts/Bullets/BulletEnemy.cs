﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    [SerializeField]
    private float moveSpeed;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        Move(moveSpeed);
        Resize(moveSpeed);
        DestroyMe(lifespan);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            player.currentHealth -= DealDamage(attack, player.defense);
            Destroy(gameObject);
        }
    }
}