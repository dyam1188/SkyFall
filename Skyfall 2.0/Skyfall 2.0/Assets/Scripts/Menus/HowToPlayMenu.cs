using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//main controller for HowToPlay Menu
//attached to Script Holder - How To Play
public class HowToPlayMenu : MonoBehaviour
{
    public bool isVisible = false;

    //text array
    [SerializeField]
    public Text[] howtoplayText = new Text[1];
    public int menuChoice = 0;

    //text sizes
    private const int fontLarge = 28;

    void Start()
    {
        howtoplayText[menuChoice].fontSize = fontLarge;
    }

    void Update()
    {

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
