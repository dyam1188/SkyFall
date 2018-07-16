﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//handles UI
//attached to Game -> UI
public class UIScript : MonoBehaviour
{
    [SerializeField]
    Image playerHealthBar, bossHealthBar;

    [SerializeField]
    GameObject[] specials = new GameObject[3];

    [SerializeField]
    Text goldText;

    PlayerController pc;
    EnemySpawn es;

    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        es = GameObject.FindWithTag("GameController").GetComponent<EnemySpawn>();

        playerHealthBar.color = pc.uiColor;
    }

    void Update()
    {
        //update player UI
        playerHealthBar.fillAmount = pc.currentHealth / pc.maxHealth;
        goldText.text = pc.gold.ToString("0");

        for (int i = 0; i < specials.Length; i++)
        {
            specials[i].gameObject.SetActive(i < pc.numSpecials ? true : false);
            specials[i].GetComponent<SpriteRenderer>().material.color = pc.uiColor;
        }

        //only enable when the boss has spawned
        foreach (Behaviour b in bossHealthBar.GetComponents<Behaviour>())
        {
            b.enabled = es.hasBossSpawned ? true : false;
        }
    }
}
