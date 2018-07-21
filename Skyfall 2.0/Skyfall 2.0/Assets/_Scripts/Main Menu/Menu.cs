using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool inputEnabled;

    protected int choice;

    [SerializeField]
    protected CanvasGroup[] canvasGroupArray;

    [SerializeField]
    protected Text[] textArray;

    //text effects
    const int large = 72;
    const int small = 60;
    float fadeSpeed = 0.1f;

    protected virtual void Start()
    {
        textArray[choice].fontSize = large;
        inputEnabled = true;
    }

    protected virtual void Update()
    {
        if (inputEnabled)
        {
            GetKeyInput();
        }
    }

    protected virtual void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && choice != 0)
        {
            choice--;
            ResizeText();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && choice != textArray.Length - 1)
        {
            choice++;
            ResizeText();
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
        {
            MakeChoice(choice);
        }
    }

    //resizes text according to menu choice
    void ResizeText()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            if (i == choice)
            {
                SetText(textArray[i], large, new Vector2(2, 2));
            }

            else
            {
                SetText(textArray[i], small, new Vector2(0, 0));
            }
        }
    }

    void SetText(Text t, int fontSize, Vector2 outlineSize)
    {
        t.fontSize = fontSize;
        t.GetComponent<Outline>().effectDistance = new Vector2(outlineSize.x, outlineSize.y);
    }

    protected virtual void MakeChoice(int choice)
    {
        //code goes in children's respective override classes
    }

    protected IEnumerator ChangeMenu(CanvasGroup canvasOut, CanvasGroup canvasIn)
    {
        inputEnabled = false;

        while (canvasOut.alpha > 0)
        {
            canvasOut.alpha -= fadeSpeed;
            yield return null;
        }

        canvasOut.gameObject.SetActive(false);
        canvasIn.gameObject.SetActive(true);

        while (canvasIn.alpha < 1)
        {
            canvasIn.alpha += fadeSpeed;
            yield return null;
        }

        inputEnabled = true;

        enabled = false;
    }

    protected void BackToMainMenu()
    {
        StartCoroutine(ChangeMenu(canvasGroupArray[0], canvasGroupArray[1]));
        GetComponent<Main>().enabled = true;
    }
}
