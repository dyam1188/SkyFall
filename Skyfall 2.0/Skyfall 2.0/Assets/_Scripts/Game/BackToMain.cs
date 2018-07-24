using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//menu handling for asking the player if they want to return to the main menu in game scenes
public class BackToMain : PauseMenu
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void MakeChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main Menu");
                break;
            case 1:
                
                break;
        }
    }
}
