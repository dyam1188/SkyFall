using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : Menu
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
                GameObject.FindWithTag("GameController").GetComponent<GameController>().isPaused = false;
                //StartCoroutine(FadeOut(GetComponent<Image>()));
                break;
            case 1:

                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Main Menu");
                break;
        }
    }

    protected IEnumerator FadeOut(Image image)
    {
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            alpha = Mathf.Round((alpha * 100) / 100);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        image.enabled = false;
        choice = 0;
    }
}
