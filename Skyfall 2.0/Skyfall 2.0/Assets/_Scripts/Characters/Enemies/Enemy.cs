using UnityEngine;

//enemy variable holder
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject {

    public Sprite enemySprite;

    [Space]

    public int health;
    public int attack;
    public int defense;
    public int moveSpeed;

    public int ammo;

}
