using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//menu handling for pause menu in game scenes
public class PauseMenu : Menu
{
    GameController gc;

    protected override void Awake()
    {
        UpdateTextSize();

        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SetOutlineColor(pc.uiColor);
    }

    void SetOutlineColor(Color c)
    {
        foreach (Text t in textArray)
        {
            t.GetComponent<Outline>().effectColor = c;
        }
    }


    protected override void Start()
    {
        base.Start();

        //hides all submenus
        for (int i = 0; i < canvasGroupArray.Length - 1; i++)
        {
            if (i != choice)
            {
                canvasGroupArray[i].gameObject.SetActive(false);
            }
        }

        gc = GetComponent<GameController>();
    }

    protected override void Update()
    {
        base.Update();
        UpdateTextSize();

        canvasGroupArray[0].gameObject.SetActive(gc.isPaused ? true : false);
    }
    
    protected override void MakeChoice(int choice)
    {
        switch (choice)
        {
            //"Resume"
            case 0:
                gc.isPaused = false;
                break;

            //"Options"
            case 1:
                ToggleCanvas(canvasGroupArray[choice]);     //enables the options canvas
                ToggleScript(GetComponent<Options>());      //enables Options.cs

                canvasGroupArray[0].alpha = 0;              //sets this menu's alpha to 0 
                ToggleScript(this);                         //turns this script off
                break;
            
            //"Back to main menu"
            case 2:
                ToggleCanvas(canvasGroupArray[choice]);     //enables the backtomain canvas
                ToggleScript(GetComponent<BackToMain>());   //enables BackToMain.cs

                canvasGroupArray[0].alpha = 0;
                ToggleScript(this);
                break;
        }
    }
}