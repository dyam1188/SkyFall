﻿using System.Collections;
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
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
                break;
            case 1:
                StartCoroutine(ChangeMenu(canvasGroupArray[0], canvasGroupArray[choice]));
                ToggleActive(this);
                ToggleActive(GetComponent<HowToPlay>());
                break;
            case 2:
                StartCoroutine(ChangeMenu(canvasGroupArray[0], canvasGroupArray[choice]));
                ToggleActive(this);
                ToggleActive(GetComponent<Options>());
                break;
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