using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{
    public bool isVisible = false;

    //options
    [SerializeField]
    private Text[] howtoplayText = new Text[1];
    public int menuChoice = 0;
    public bool howToPlayExitSelected = false;

    //text sizes
    private const int fontLarge = 28;

    void Start()
    {
        howtoplayText[menuChoice].fontSize = fontLarge;
    }

    void Update()
    {
        if (isVisible)
        {
            if (menuChoice == howtoplayText.Length - 1)
            {
                howToPlayExitSelected = true;
            }
            else
            {
                howToPlayExitSelected = false;
            }
        }
    }

    //scales the selected menu option larger
    void ResizeText()
    {
        for (int i = 0; i < howtoplayText.Length; i++)
        {
            if (i == menuChoice)
            {
                SetText(howtoplayText[i], fontLarge);
            }
        }
    }

    //scales the selected text
    Text SetText(Text t, int size)
    {
        t.fontSize = size;
        return t;
    }
}
