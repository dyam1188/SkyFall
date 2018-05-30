using UnityEngine;

//bullet variable holder
[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class Bullet : ScriptableObject {

    public Sprite bulletSprite;

    [Space]

    public int moveSpeed;
    public float lifespan;

    public int maxMoveSpeed = 10;
}
