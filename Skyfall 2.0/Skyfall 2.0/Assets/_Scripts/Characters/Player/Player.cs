using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player variable holder
[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public Sprite sprite;
    public Color uiColor;

    [Space]

    public GameObject bullet;
    public ParticleSystem special;

    [Space]

    public int numLives;
    public int numSpecials;

    [Space]

    public float currentHealth;
    public float maxHealth;
    public float attack;
    public float defense;
    public float moveSpeed;
    public float attackSpeed;
    public float specialCooldown;       //how long the player has to wait before using another special

    public const int maxLives = 3;
    public const int maxSpecials = 3;
    
}