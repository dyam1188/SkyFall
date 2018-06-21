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
    private Slider healthSlider;

    [SerializeField]
    private Image healthSliderFill;

    [SerializeField]
    private GameObject[] specialBars = new GameObject[3];

    void Start()
    {

    }

    void Update()
    {
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        healthSliderFill.color = pc.uiColor;
        healthSlider.value = pc.currentHealth / pc.maxHealth;
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
    }
}
