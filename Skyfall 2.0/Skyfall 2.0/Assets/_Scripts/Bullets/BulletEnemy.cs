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

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            DamageCalculator dc = GetComponent<DamageCalculator>();
            float damage = dc.CalculateDamage(attack, player.defense);
            player.health -= damage;
            Debug.Log(damage);
            Destroy(gameObject);
        }
    }
}