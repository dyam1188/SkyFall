using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public int gold;
    private int numSpecials;

    [SerializeField]
    Text GoldText;

    public Transform UICanvas;
    public Slider healthSlider;

    [SerializeField]
    private Image healthSliderFill;

    [SerializeField]
    private GameObject[] specialBars = new GameObject[3];

    void Start()
    {
        specialBars[0].gameObject.SetActive(false);
        specialBars[1].gameObject.SetActive(false);
        specialBars[2].gameObject.SetActive(false);
    }

    void Update()
    {
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        healthSliderFill.color = pc.uiColor;
        healthSlider.value = pc.currentHealth / pc.maxHealth;
        GoldText.text = pc.gold.ToString();
        numSpecials = pc.numSpecials;

        switch (numSpecials)
        {
            case 0:
                specialBars[0].gameObject.SetActive(false);
                specialBars[1].gameObject.SetActive(false);
                specialBars[2].gameObject.SetActive(false);
            break;

            case 1:
                specialBars[0].gameObject.SetActive(true);
                specialBars[1].gameObject.SetActive(false);
                specialBars[2].gameObject.SetActive(false);
            break;

            case 2:
                specialBars[0].gameObject.SetActive(true);
                specialBars[1].gameObject.SetActive(true);
                specialBars[2].gameObject.SetActive(false);
            break;

            case 3:
                specialBars[0].gameObject.SetActive(true);
                specialBars[1].gameObject.SetActive(true);
                specialBars[2].gameObject.SetActive(true);
            break;
        }
    }
}
