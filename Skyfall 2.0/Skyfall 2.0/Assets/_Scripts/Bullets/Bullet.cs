using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent Bullet class
public class Bullet : MonoBehaviour
{
    protected PlayerController player;  //reference to player

    //this is serialized so that enemy bullets will have their attack values directly set in the Inspector
    //the player bullets' attack can be grabbed from the player in the scene because there is always only one player
    [SerializeField]
    protected float attack;
    protected float lifespan = 3f;

    private float slowSpeed = 10f;

    [SerializeField]
    private ParticleSystem bulletDestruction;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    protected void Move(float speed)
    {
        transform.Translate((Vector3.up * speed) * Time.deltaTime);
        speed -= slowSpeed * Time.deltaTime;            //decreases its speed over time
    }

    //resizes the bullet so that the faster it moves, the more it stretches
    protected void Resize(float speed)
    {
        //clamps stretch/squish factor to a min and max to make the bullets not look unrealistic
        int min = 1, max = 4;
        float stretch = Mathf.Clamp(speed, min, max);
        float squish = Mathf.Clamp(speed, min, max);

        transform.localScale = new Vector2(squish / speed, speed / stretch);
    }

    //destroys bullet after <lifespan> if it doesn't collide into anything
    protected void DestroyMe(float lifespan)
    {
        Destroy(gameObject, lifespan);
        //play particle effect here
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected float DealDamage(float attack, float defense)
    {
        DamageCalculator dc = GetComponent<DamageCalculator>();
        float damage = dc.CalculateDamage(attack, defense);
        Debug.Log(damage);
        return damage;
    }
}