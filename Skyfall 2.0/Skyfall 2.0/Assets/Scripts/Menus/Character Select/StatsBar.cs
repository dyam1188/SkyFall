using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    [SerializeField]
    private GameObject[] statBars = new GameObject[4];

    [Space]

    //Get stats of each class
    public Player[] players = new Player[4];

    [Space]

    [SerializeField]
    [Tooltip("Stat bar sprite")]
    private Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        for (int i = 0; i < statBars.Length; i++)
        {
            mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }
    }

    void Update()
    {
        sr.sprite = mySprite;
    }

    public void Resize(Player player)
    {

    }
}
