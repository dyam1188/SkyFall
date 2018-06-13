﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    [SerializeField]
    private float moveSpeed;
    private float lifespan = 1f;

    [SerializeField]
    private ParticleSystem ps_BulletDestruction;

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
        if (c.tag == "Enemy")
        {
            DamageCalculator dc = GetComponent<DamageCalculator>();
            EnemyCommon ec = c.GetComponent<EnemyCommon>();
            float damage = dc.CalculateDamage(attack, ec.defense);
            ec.health -= damage;
            Debug.Log(damage);
            Destroy(gameObject);
        }
    }
}