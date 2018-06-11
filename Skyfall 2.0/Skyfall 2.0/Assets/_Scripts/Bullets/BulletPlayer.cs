using System.Collections;
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

    protected override void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            base.OnTriggerEnter2D(c);
            CalculateDamage(c);
        }
    }

    //CalculateDamage.cs will be used instead of this
    void CalculateDamage(Collider2D c)
    {
        EnemyCommon ec = c.GetComponent<EnemyCommon>();
        ec.health -= attack;
    }
}