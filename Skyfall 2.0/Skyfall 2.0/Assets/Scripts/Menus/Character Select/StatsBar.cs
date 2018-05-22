using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    //int menuChoice = 0;

    [SerializeField]
    private CharacterSelect cs;

    [Space]

    [SerializeField]
    private GameObject[] statBars = new GameObject[4];

    [Space]

    //Get stats of each class
    [SerializeField]
    private Player[] players = new Player[4];
    private int[] baseHP = new int[4];
    private int[] baseAttack = new int[4];
    private int[] baseDefense = new int[4];
    private int[] baseSpeed = new int[4];

    [Space]

    [SerializeField]
    [Tooltip("Stat bar sprite")]
    private Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;
    private Vector2 pivot = new Vector2(0.0f, 0.5f);

    void Start()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;

        for (int i = 0; i < players.Length; i++)
        {
            baseHP[i] = players[i].health;
            baseAttack[i] = players[i].attack;
            baseDefense[i] = players[i].defense;
            baseSpeed[i] = players[i].moveSpeed;
        }
    }

    void Update()
    {
        sr.sprite = mySprite;
        Resize();
    }

    void Resize()
    {
        for (int i = 0; i < statBars.Length; i++)
        {
            //Menu choice 0 = Red
            //Menu choice 1 = Blue
            //Menu choice 2 = Yellow
            //Menu choice 3 = Green

            switch (i)
            {
                case 0:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].health / Mathf.Max(baseHP)), tex.height), pivot);
                    break;

                case 1:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].attack / Mathf.Max(baseAttack)), tex.height), pivot);
                    break;

                case 2:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].defense / Mathf.Max(baseDefense)), tex.height), pivot);
                    break;

                case 3:
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)), tex.height), pivot);
                    break;
            }

            statBars[i].GetComponent<SpriteRenderer>().sprite = mySprite;

            //Updates Health Bar
            /*if (i == 0)
            {
                if (cs.menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].health / Mathf.Max(baseHP)), tex.height), pivot);
                }

                if (cs.menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].health / Mathf.Max(baseHP)), tex.height), pivot);
                }

                if (cs.menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].health / Mathf.Max(baseHP)), tex.height), pivot);
                }

                if (cs.menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].health / Mathf.Max(baseHP)), tex.height), pivot);
                }
            }

            //Updates Attack Bar
            if (i == 1)
            {
                if (cs.menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].attack / Mathf.Max(baseAttack)), tex.height), pivot);
                }

                if (cs.menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].attack / Mathf.Max(baseAttack)), tex.height), pivot);
                }

                if (cs.menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].attack / Mathf.Max(baseAttack)), tex.height), pivot);
                }

                if (cs.menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].attack / Mathf.Max(baseAttack)), tex.height), pivot);
                }
            }

            //Updates Defense Bar
            if (i == 2)
            {
                if (cs.menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].defense / Mathf.Max(baseDefense)), tex.height), pivot);
                }

                if (cs.menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].defense / Mathf.Max(baseDefense)), tex.height), pivot);
                }

                if (cs.menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].defense / Mathf.Max(baseDefense)), tex.height), pivot);
                }

                if (cs.menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].defense / Mathf.Max(baseDefense)), tex.height), pivot);
                }
            }

            //Updates Speed Bar
            if (i == 3)
            {
                if (cs.menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)), tex.height), pivot);
                }

                if (cs.menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)), tex.height), pivot);
                }

                if (cs.menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)), tex.height), pivot);
                }

                if (cs.menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width * ((float)players[cs.menuChoice].moveSpeed / Mathf.Max(baseSpeed)), tex.height), pivot);
                }
            }
            */
        }
    }
}
