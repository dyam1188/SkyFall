using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//parent menu class
public class Menu : MonoBehaviour
{
    bool inputEnabled;

    protected int choice;

    [SerializeField]
    protected CanvasGroup[] canvasGroupArray;

    [SerializeField]
    protected Text[] textArray;

    //text effects
    const int large = 60;
    const int small = 48;
    const float fadeSpeed = 0.1f;

    protected virtual void Awake()
    {
        UpdateTextSize();
    }

    protected virtual void Start()
    {
        inputEnabled = true;
    }

    protected virtual void Update()
    {
        if (inputEnabled && gameObject.activeSelf)
        {
            GetKeyInput();
        }
        UpdateTextSize();
    }

    protected virtual void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && choice != 0)
        {
            choice--;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && choice != textArray.Length - 1)
        {
            choice++;
        }

        if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.Space))
        {
            MakeChoice(choice);
        }
    }

    //resizes text according to menu choice
    protected void UpdateTextSize()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].fontSize = i == choice ? large : small;
            textArray[i].GetComponent<Outline>().enabled = i == choice ? true : false;
        }
    }

    protected virtual void MakeChoice(int choice)
    {
        //code goes in children's respective override classes
    }

    //sets the canvasGroup active if it isn't active, and vice versa
    protected void ToggleCanvas(CanvasGroup cg)
    {
        cg.gameObject.SetActive(cg.gameObject.activeSelf ? false : true);
    }

    //enables the script if it is disabled, and vice versa
    protected void ToggleScript(Behaviour script)
    {
        script.enabled = script.enabled ? false : true;
    }

    protected void HideTextIfDisabled()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i].gameObject.SetActive(enabled ? true : false);
        }
    }

    //only used in main menu scene
    protected void BackToMainMenu()
    {
        ToggleCanvas(canvasGroupArray[0]);
        ToggleScript(GetComponent<Main>());

        choice = 0;

        ToggleCanvas(canvasGroupArray[1]);
        ToggleScript(this);
    }
    
    //only used in game scenes
    protected void BackToPauseMenu()
    {
        canvasGroupArray[0].alpha = 1;
        ToggleScript(GetComponent<PauseMenu>());

        choice = 0;

        ToggleCanvas(canvasGroupArray[1]);
        ToggleScript(this);
    }
}
