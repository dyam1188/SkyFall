using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    [SerializeField]
    private float moveSpeed;
    private float lifespan = 1f;

    [SerializeField]
    private ParticleSystem ps_BulletDestruction;

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

    protected override void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            base.OnTriggerEnter2D(c);
            CalculateDamage();
        }
    }

    //CalculateDamage.cs will be used instead of this
    void CalculateDamage()
    {
        player.health -= attack;
        Debug.Log(player.health);
    }
}