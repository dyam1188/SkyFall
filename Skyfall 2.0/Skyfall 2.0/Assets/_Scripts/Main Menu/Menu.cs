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
    protected const float fadeSpeed = 0.1f;

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

        ResizeText();
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
            textArray[i].fontSize = i == choice ? large : small;
            textArray[i].GetComponent<Outline>().enabled = i == choice ? true : false;
        }
    }

    protected virtual void MakeChoice(int choice)
    {
        //code goes in children's respective override classes
    }

    protected void ToggleActive(Main m, HowToPlay h)
    {
        m.enabled = m.enabled ? false : true;
        h.enabled = h.enabled ? false : true;
    }

    protected void ToggleActive(Main m, Options o)
    {
        m.enabled = m.enabled ? false : true;
        o.enabled = o.enabled ? false : true;
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
        choice = 0;
        canvasIn.gameObject.SetActive(true);

        while (canvasIn.alpha < 1)
        {
            canvasIn.alpha += fadeSpeed;
            yield return null;
        }

        inputEnabled = true;

        enabled = false;
    }

    protected virtual void BackToMainMenu()
    {
        StartCoroutine(ChangeMenu(canvasGroupArray[0], canvasGroupArray[1]));
    }
}
