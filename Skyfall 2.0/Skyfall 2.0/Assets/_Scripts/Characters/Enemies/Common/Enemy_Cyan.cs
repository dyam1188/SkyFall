using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cyan : Enemy
{
    protected override void Start()
    {

    }

    protected override void Update()
    {
        base.Update();
        Move(moveSpeed);
    }

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }
}
