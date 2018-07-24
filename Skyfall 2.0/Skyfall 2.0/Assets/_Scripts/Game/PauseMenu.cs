using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//menu handling for pause menu in game scenes
public class PauseMenu : Menu
{
    const int large = 48;
    const int small = 36;

    protected override void Awake()
    {
        ResizeText(large, small);
        PlayerController pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SetOutlineColor(pc.uiColor);
        HideAllSubmenus();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        ResizeText(large, small);
    }

    void SetOutlineColor(Color c)
    {
        foreach(Text t in textArray)
        {
            t.GetComponent<Outline>().effectColor = c;
        }
    }

    //disables all children in all elements of textArray
    public void HideAllSubmenus()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].gameObject.SetActive(true);

            foreach(Transform child in textArray[i].GetComponentInChildren<Transform>())
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    protected override void MakeChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                GameObject.FindWithTag("GameController").GetComponent<GameController>().isPaused = false;
                break;
            case 1:

                break;
            case 2:
                ChangeMenu(canvasGroupArray[0], canvasGroupArray[1]);
                /*for (int i = 0; i < textArray.Length; i++)
                {
                    textArray[i].gameObject.SetActive(false);
                }

                foreach (Transform child in textArray[choice].GetComponentInChildren<Transform>())
                {
                    child.gameObject.SetActive(true);
                }*/

                break;
        }
    }
}
