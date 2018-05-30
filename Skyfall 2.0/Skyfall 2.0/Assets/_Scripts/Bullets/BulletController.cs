using UnityEngine;

//controls the bullet
public class BulletController : MonoBehaviour
{
    public Bullet bullet;

    private SpriteRenderer sr;
    private int moveSpeed;
    private float lifespan;
 
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = bullet.bulletSprite;

        moveSpeed = Mathf.Clamp(bullet.moveSpeed, 0, bullet.maxMoveSpeed);
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
        Resize(moveSpeed);
    }

    void Resize(float s)
    {
        //i want to resize the bullet so that the faster it moves, the more it stretches
    }
}
