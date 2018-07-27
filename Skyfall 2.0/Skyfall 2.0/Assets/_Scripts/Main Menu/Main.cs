using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//menu handling for main menu
public class Main : Menu
{
    protected override void Awake()
    {
        base.Awake();
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
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void MakeChoice(int choice)
    {
        switch (choice)
        {
            //"Play"
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
                break;

            //"How to Play"
            case 1:
                ToggleCanvas(canvasGroupArray[0]);
                ToggleCanvas(canvasGroupArray[choice]);
                ToggleScript(this);
                ToggleScript(GetComponent<HowToPlay>());
                break;

            //"Options"
            case 2:
                ToggleCanvas(canvasGroupArray[0]);
                ToggleCanvas(canvasGroupArray[choice]);
                ToggleScript(this);
                ToggleScript(GetComponent<Options>());
                break;

            //"Exit"
            case 3:
                Quit();
                break;
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}