using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//returns damage by passing raw damage through damage formula
public class DamageCalculator : MonoBehaviour
{
    //how much to randomize the damage by
    //we don't want the damage amount to be the exact same every single time
    float variance = 0.05f;
    float atkVariance = 0.04f;
    float defVariance = 0.02f;

    public float CalculateDamage(float attack, float defense)
    {
        float damage = attack - defense;

        //add variance, set minimum damage to 1, and round it back to a whole number
        damage = Mathf.Max(Mathf.Round(damage * (1 + Random.Range(-variance, variance))), 1);

        return damage;
    }
}
