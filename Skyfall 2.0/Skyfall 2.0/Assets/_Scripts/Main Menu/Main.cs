using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : Menu
{
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
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("CharacterSelect");
                break;
            case 1:
                StartCoroutine(ChangeMenu(canvasGroupArray[0], canvasGroupArray[choice]));
                ToggleActive(this, GetComponent<HowToPlay>());
                break;
            case 2:
                StartCoroutine(ChangeMenu(canvasGroupArray[0], canvasGroupArray[choice]));
                ToggleActive(this, GetComponent<Options>());
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