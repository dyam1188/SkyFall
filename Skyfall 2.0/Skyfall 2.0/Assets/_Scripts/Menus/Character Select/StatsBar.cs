using UnityEngine;
using System;
//resizes the stat bars
//attached to CharacterSelect -> Script Holder - Stats Bar
public class StatsBar : MonoBehaviour
{
    private CharacterSelect cs;

    [Space]

    [SerializeField]
    private GameObject[] statBars = new GameObject[4];

    [Space]

    //Hold stats of each playable character
    [SerializeField]
    private Player[] players = new Player[4];

    private float[] baseHealth = new float[4];
    private float[] baseAttack = new float[4];
    private float[] baseDefense = new float[4];
    private int[] baseSpeed = new int[4];

    [Space]

    [SerializeField]
    [Tooltip("Stat bar sprite")]
    private Texture2D tex;

    private Sprite mySprite;
    private Vector2 pivot = new Vector2(0.0f, 0.5f);

    void Start()
    {
        cs = GetComponent<CharacterSelect>();

        for (int i = 0; i < players.Length; i++)
        {
            baseHealth[i] = players[i].maxHealth;
            baseAttack[i] = players[i].attack;
            baseDefense[i] = players[i].defense;
            baseSpeed[i] = players[i].moveSpeed;
        }

        Array.Sort(baseHealth);
        Array.Sort(baseAttack);
        Array.Sort(baseDefense);
        Array.Sort(baseSpeed);
    }

    void Update()
    {
        Resize();
    }

    void Resize()
    {
        for (int i = 0; i < statBars.Length; i++)
        {
            switch (i)
            {
                //health bar
                case 0:
                    mySprite = SetSprite(tex.width * (players[cs.menuChoice].maxHealth / Mathf.Max(baseHealth)));
                    //mySprite = SetSprite(tex.width * (Array.IndexOf(baseHealth, players[cs.menuChoice].maxHealth) / players.Length));
                    break;

                //attack bar
                case 1:
                    mySprite = SetSprite(tex.width * (players[cs.menuChoice].attack / Mathf.Max(baseAttack)));
                    //mySprite = SetSprite(tex.width * (Array.IndexOf(baseAttack, players[cs.menuChoice].attack) / players.Length));
                    break;

                //defense bar
                case 2:
                    mySprite = SetSprite(tex.width * (players[cs.menuChoice].defense / Mathf.Max(baseDefense)));
                    //mySprite = SetSprite(tex.width * (Array.IndexOf(baseDefense, players[cs.menuChoice].defense) / players.Length));
                    break;

                //speed bar
                case 3:
                    mySprite = SetSprite(tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)));
                    //mySprite = SetSprite(tex.width * (Array.IndexOf(baseSpeed, players[cs.menuChoice].moveSpeed) / players.Length));
                    break;
            }

            statBars[i].GetComponent<SpriteRenderer>().sprite = mySprite;
        }
    }

    Sprite SetSprite(float width)
    {
        Sprite s = Sprite.Create(tex, new Rect(0, 0, width, tex.height), pivot);
        return s;
    }
}
