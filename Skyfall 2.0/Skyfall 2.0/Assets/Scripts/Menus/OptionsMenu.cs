﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//main controller for Options Menu
//attached to Main Menu - Script Holder - Options
public class OptionsMenu : MonoBehaviour
{
    public bool isVisible = false;

    //sliders
    [SerializeField]
    Slider slider_bgm;
    [SerializeField]
    Slider slider_sfx;

    //options
    [SerializeField]
    private Text[] t_options = new Text[3];
    public int menuChoice = 0;
    public bool optionsExitSelected = false;

    //text sizes
    private const int fontLarge = 28;
    private const int fontSmall = 22;

    void Start()
    {
        t_options[menuChoice].fontSize = fontLarge;
    }

    void Update()
    {
        if (isVisible)
        {
            GetKeyInput();

            if (menuChoice == t_options.Length - 1)
            {
                optionsExitSelected = true;
            }
            else
            {
                optionsExitSelected = false;
            }
        }
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && menuChoice != 0)
        {
            menuChoice--;
            ResizeText();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && menuChoice != t_options.Length - 1)
        {
            menuChoice++;
            ResizeText();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            switch (menuChoice)
            {
                case 0:
                    ChangeBGMVolume(-1);
                    break;
                case 1:
                    ChangeSFXVolume(-1);
                    break;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            switch (menuChoice)
            {
                case 0:
                    ChangeBGMVolume(1);
                    break;
                case 1:
                    ChangeSFXVolume(1);
                    break;
            }
        }
    }

    //scales the selected menu option larger
    void ResizeText()
    {
        for (int i = 0; i < t_options.Length; i++)
        {
            if (i == menuChoice)
            {
                SetText(t_options[i], fontLarge);
            }
            else
            {
                SetText(t_options[i], fontSmall);
            }
        }
    }

    //scales the selected text
    Text SetText(Text t, int size)
    {
        t.fontSize = size;
        return t;
    }

    public void ChangeBGMVolume(int changeValue)
    {
        slider_bgm.value += changeValue;
    }

    public void ChangeSFXVolume(int changeValue)
    {
        slider_sfx.value += changeValue;
    }
}