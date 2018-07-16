using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Orange : Enemy
{
    protected override void Start()
    {
        base.Start();
        LookAtPlayer();
    }

    protected override void Update()
    {
        base.Update();
        Move(moveSpeed);
        Shoot();
    }

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }
}
