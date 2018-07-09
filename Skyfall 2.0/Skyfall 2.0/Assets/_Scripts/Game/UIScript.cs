using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    Image healthFill;

    [SerializeField]
    GameObject[] specials = new GameObject[3];

    [SerializeField]
    Text goldText;

    PlayerController pc;

    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        healthFill.color = pc.uiColor;
    }

    void Update()
    {
        healthFill.fillAmount = pc.currentHealth / pc.maxHealth;
        goldText.text = pc.gold.ToString();

        for (int i = 0; i < specials.Length; i++)
        {
            if (i < pc.numSpecials)
            {
                specials[i].gameObject.SetActive(true);
            }
            else
            {
                specials[i].gameObject.SetActive(false);
            }

            specials[i].GetComponent<SpriteRenderer>().material.color = pc.uiColor;
        }
    }
}
