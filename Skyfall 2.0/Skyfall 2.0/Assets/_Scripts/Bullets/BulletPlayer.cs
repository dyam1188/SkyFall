using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
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
}