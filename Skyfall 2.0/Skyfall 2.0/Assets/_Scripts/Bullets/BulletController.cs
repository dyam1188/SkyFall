using UnityEngine;

//controls the bullet
public class BulletController : MonoBehaviour
{
    public Bullet bullet;

    private SpriteRenderer sr;
    private float moveSpeed;
    private float lifespan;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = bullet.bulletSprite;
        moveSpeed = bullet.moveSpeed;
        lifespan = bullet.lifespan;

        Resize(moveSpeed);
    }

    void Update()
    {
        Move();
        Destroy(gameObject, lifespan);
    }

    void Move()
    {
        transform.Translate((Vector3.up * moveSpeed) * Time.deltaTime);
        moveSpeed += Time.deltaTime * 5;
        Resize(moveSpeed);
    }

    //resize the bullet so that the faster it moves, the more it stretches
    void Resize(float s)
    {
        float stretch = Mathf.Clamp(moveSpeed, 1, 4);
        float squish = Mathf.Clamp(moveSpeed, 1, 4);

        sr.transform.localScale = new Vector2(squish / moveSpeed, moveSpeed / stretch);
    }
}