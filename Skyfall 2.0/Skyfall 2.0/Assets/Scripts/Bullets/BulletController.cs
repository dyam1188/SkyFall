using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls the bullet
public class BulletController : MonoBehaviour
{
    public Bullet bullet;

    private Sprite bulletSprite;

    private int moveSpeed;
    private float lifespan;
 
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullet.bulletSprite;

        moveSpeed = bullet.moveSpeed;
        lifespan = bullet.lifespan;


    }

    void Update()
    {
        Move();
        Destroy(gameObject, lifespan);
    }

    void Move()
    {
        transform.Translate((Vector3.up * moveSpeed) * Time.deltaTime);
    }
}
