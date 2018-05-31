using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Common", menuName = "Enemy Common")]
public class EnemyCommon : ScriptableObject {
    public Sprite enemySprite;
    public Bullet enemyBullet;

    [Space]

    public int health;
    public int attack;
    public int defense;
    public int moveSpeed;
    public int shotDensity;
}