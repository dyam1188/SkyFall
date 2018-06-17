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
    public Slider HealthSlider;
    public Player player;

    void Start()
    {
        gold = 0;

        //HealthSlider.value = currentHealth / maxHealth;
    }

    void Update()
    {
        GoldText.text = gold.ToString();
    }
}
