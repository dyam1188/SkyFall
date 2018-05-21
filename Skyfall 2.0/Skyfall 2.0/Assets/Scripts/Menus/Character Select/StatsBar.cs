using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour {

    [SerializeField]
    GameObject HPBar;

    [SerializeField]
    GameObject AttackBar;

    [SerializeField]
    GameObject DefenseBar;

    [SerializeField]
    GameObject SpeedBar;

    //Get stats of each class
    public Player red;
    public Player blue;
    public Player green;
    public Player yellow;

    public Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
	
	// Update is called once per frame
	void Update () {
        sr.sprite = mySprite;
    }
}
