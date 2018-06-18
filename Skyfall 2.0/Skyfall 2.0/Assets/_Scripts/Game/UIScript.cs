using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public int gold;

    [SerializeField]
    Text GoldText;

    public Transform UICanvas;
    public Slider healthSlider;

    [SerializeField]
    private Image healthSliderFill;

    void Start()
    {
        //healthSlider.value = currentHealth / maxHealth;
    }

    void Update()
    {
        GoldText.text = gold.ToString();

        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        healthSliderFill.color = pc.uiColor;
    }
}
