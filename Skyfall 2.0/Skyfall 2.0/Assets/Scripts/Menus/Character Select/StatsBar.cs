using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    int menuChoice = 0;

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
    private Sprite attackSprite;
    private Sprite defenseSprite;
    private Sprite healthSprite;
    private Sprite speedSprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        Resize(players[menuChoice]);

        for (int i = 0; i < statBars.Length; i++)
        {
            mySprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.0f, 0.5f));
        }
    }

    void Update()
    {
        sr.sprite = mySprite;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && menuChoice != 0)
        {
            menuChoice--;
            Resize(players[menuChoice]);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && menuChoice != 3)
        {
            menuChoice++;
            Resize(players[menuChoice]);
        }
    }


    public void Resize(Player player)
    {
        for (int i = 0; i < statBars.Length; i++)
        {
            //Menu choice 0 = Red
            //Menu choice 1 = Blue
            //Menu choice 2 = Yellow
            //Menu choice 3 = Green

            //Updates Health Bar
            if (i == 0)
            {
                if (menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.health / player.health * 256, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.health / player.health * 512, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.health / player.health * 102, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.health / player.health * 205, tex.height), new Vector2(0.0f, 0.5f));
                }
            }

            //Updates Attack Bar
            if (i == 1)
            {
                if (menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.attack / player.attack * 512, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.attack / player.attack * 102, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.attack / player.attack * 307, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.attack / player.attack * 307, tex.height), new Vector2(0.0f, 0.5f));
                }
            }

            //Updates Defense Bar
            if (i == 2)
            {
                if (menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.defense / player.defense * 102, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.defense / player.defense * 512, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.defense / player.defense * 256, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.defense / player.defense * 204, tex.height), new Vector2(0.0f, 0.5f));
                }
            }

            //Updates Speed Bar
            if (i == 3)
            {
                if (menuChoice == 0)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.moveSpeed / player.moveSpeed * 204, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 1)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.moveSpeed / player.moveSpeed * 102, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 2)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.moveSpeed / player.moveSpeed * 512, tex.height), new Vector2(0.0f, 0.5f));
                }

                if (menuChoice == 3)
                {
                    mySprite = Sprite.Create(tex, new Rect(0, 0, player.moveSpeed / player.moveSpeed * 256, tex.height), new Vector2(0.0f, 0.5f));
                }
            }

            statBars[i].GetComponent<SpriteRenderer>().sprite = mySprite;
        }
    }
}
