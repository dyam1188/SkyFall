using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Purple : Enemy
{
    protected override void Start()
    {
        base.Start();
        moveSpeed *= transform.position.x > 0 ? -1 : 1;         //reverse moveSpeed if it spawns on the right side of the screen
    }

    protected override void Update()
    {
        base.Update();
        Move(moveSpeed);
        LookAtPlayer();
        Shoot();
    }

    protected override void Move(float speed)
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
    }

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }
}
