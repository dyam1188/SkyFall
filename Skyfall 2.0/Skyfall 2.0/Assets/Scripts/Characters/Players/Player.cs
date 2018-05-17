using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player variable holder
[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject {

    public Sprite playerSprite;

    [Space]

    public int numLives;
    public int numSpecials;
    public int health;
    public int attack;
    public int defense;

    [Space]

    public float moveSpeed;
    public float shotDensity;

    public const int maxLives = 3;
    public const int maxSpecial = 3;
}