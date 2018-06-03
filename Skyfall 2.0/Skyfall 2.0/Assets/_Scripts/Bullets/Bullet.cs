using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    protected void Move(float speed)
    {
        transform.Translate((Vector3.up * speed) * Time.deltaTime);
        speed -= Time.deltaTime * 3;
    }

    //resize the bullet so that the faster it moves, the more it stretches
    protected void Resize(float speed)
    {
        float stretch = Mathf.Clamp(speed, 1, 4);
        float squish = Mathf.Clamp(speed, 1, 4);

        transform.localScale = new Vector2(squish / speed, speed / stretch);
    }

    protected void Destroy(float lifespan)
    {
        Destroy(gameObject, lifespan);
    }
}
