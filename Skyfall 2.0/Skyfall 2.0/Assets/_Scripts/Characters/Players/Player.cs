using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player variable holder
[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public Sprite playerSprite;
    public Bullet playerBullet;

    [Space]

    public int numLives;
    public int numSpecials;

    [Space]

    public float health;
    public float attack;
    public float defense;
    public int moveSpeed;
    public int shotDensity;

    public const int maxLives = 3;
    public const int maxSpecial = 3;
}