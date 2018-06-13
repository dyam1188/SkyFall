using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to return damage by passing raw damage through damage formula
public class DamageCalculator : MonoBehaviour
{
    //how much to randomize the damage by
    //we don't want the damage amount to be the exact same every single time
    float variance = 0.01f;

    public float CalculateDamage(float attack, float defense)
    {
        float damage = (attack - defense);

        //add variance and round it back to a whole number
        damage = Mathf.Round(damage * (1 + Random.Range(-variance, variance)));
        return damage;
    }
}
