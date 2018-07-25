using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//menu handling for pause menu in game scenes
public class PauseMenu : Menu
{
    const int large = 48;
    const int small = 36;

    GameController gc;

    protected override void Awake()
    {
        ResizeText(large, small);

        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SetOutlineColor(pc.uiColor);
    }

    protected override void Start()
    {
        base.Start();

        for (int i = 0; i < canvasGroupArray.Length - 1; i++)
        {
            if (i != choice)
            {
                canvasGroupArray[i].gameObject.SetActive(false);
            }
        }

        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    protected override void Update()
    {
        base.Update();
        ResizeText(large, small);

        canvasGroupArray[0].alpha = gc.isPaused ? 1 : 0;
    }

    void SetOutlineColor(Color c)
    {
        foreach (Text t in textArray)
        {
            t.GetComponent<Outline>().effectColor = c;
        }
    }

    protected override void MakeChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                gc.isPaused = false;
                break;
            case 1:

                break;
            case 2:
                canvasGroupArray[0].gameObject.SetActive(false);
                canvasGroupArray[1].gameObject.SetActive(true);
                ToggleActive(this);
                ToggleActive(GetComponent<BackToMain>());
                break;
        }
    }
}