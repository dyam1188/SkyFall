using UnityEngine;

//bullet variable holder
[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class Bullet : ScriptableObject {

    public Sprite bulletSprite;

    [Space]

    public float moveSpeed;
    public float lifespan;

    public float maxMoveSpeed = 10f;
}
