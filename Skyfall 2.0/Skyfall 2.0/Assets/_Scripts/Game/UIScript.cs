using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public int gold;

    [SerializeField]
    Text GoldText;

    public Transform UICanvas;
    public Slider HealthSlider;
    public Player player;

    // Use this for initialization
    void Start () {
        gold = 000;

        //HealthSlider.value = currentHealth / maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
        GoldText.text = gold.ToString();
    }
}
