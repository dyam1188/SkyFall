using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public int gold;

    [SerializeField]
    private Text goldText;

    [SerializeField]
    private Image hpFill;

    [SerializeField]
    private GameObject[] specialBars = new GameObject[3];

    PlayerController pc;

    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        hpFill.color = pc.uiColor;
    }

    void Update()
    {
        hpFill.GetComponent<Image>().fillAmount = pc.currentHealth / pc.maxHealth;
        goldText.text = pc.gold.ToString();

        for (int i = 0; i < specialBars.Length; i++)
        {
            if (i < pc.numSpecials)
            {
                specialBars[i].gameObject.SetActive(true);
            }
            else
            {
                specialBars[i].gameObject.SetActive(false);
            }

            specialBars[i].GetComponent<SpriteRenderer>().material.color = pc.uiColor;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(hpFill.GetComponent<Image>().fillAmount);
        }
    }
}
