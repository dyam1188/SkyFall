using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//main controller for Main Menu
//attached to Main Menu -> Script Holder - Main Menu
public class MainMenu : MonoBehaviour
{
    private int menuChoice = 1;                     //initialized to 1 because index 0 is the logo
    private bool isMainVisible = true;

    [SerializeField]
    private Canvas mainCanvas;

    [SerializeField]
    private Image[] menuText = new Image[5];

    [Space]

    [SerializeField]
    private Canvas howtoplayCanvas;
    public HowToPlayMenu howtoplayMenu;

    [Space]

    [SerializeField]
    private Canvas optionsCanvas;
    public OptionsMenu optionsMenu;

    private const float fadeSpeed = 0.05f;  //the rate at which objects fade in or out per frame

    //text sizes
    private Vector3 textSmall = new Vector3(1f, 1f, 1f);
    private Vector3 textLarge = new Vector3(1.25f, 1.25f, 1f);

    void Start()
    {
        StartCoroutine(CanvasFadeIn(mainCanvas));

        //set default menu choice
        menuText[menuChoice].rectTransform.localScale = textLarge;

        //set how to play canvas alpha to 0
        howtoplayCanvas.GetComponent<CanvasGroup>().alpha = 0;

        //set options canvas alpha to 0
        optionsCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }

    void Update()
    {
        GetKeyInput();
    }

    //controls main menu selection
    void GetKeyInput()
    {
        if (isMainVisible)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && menuChoice != 1)
            {
                menuChoice--;
                ResizeText();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && menuChoice != menuText.Length - 1)
            {
                menuChoice++;
                ResizeText();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
        {
            if (isMainVisible)
            {
                MakeSelection();
            }

            /*else if (howtoplayMenu.isVisible)
            {

            }*/

            else if (optionsMenu.isVisible && optionsMenu.optionsExitSelected == true)
            {
                SetCanvas(mainCanvas, optionsCanvas);
                isMainVisible = true;
                optionsMenu.isVisible = false;
            }
        }

        if (!isMainVisible && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape)))
        {
            if (howtoplayMenu.isVisible)
            {
                SetCanvas(mainCanvas, howtoplayCanvas);
                isMainVisible = true;
                howtoplayMenu.isVisible = false;
            }

            if (optionsMenu.isVisible)
            {
                SetCanvas(mainCanvas, optionsCanvas);
                isMainVisible = true;
                optionsMenu.isVisible = false;
            }
        }
    }

    //scales the selected menu option larger
    void ResizeText()
    {
        for (int i = 1; i < menuText.Length; i++)
        {
            if (i == menuChoice)
            {
                SetText(menuText[i], textLarge);
            }
            else
            {
                SetText(menuText[i], textSmall);
            }
        }
    }

    //scales the selected text
    Image SetText(Image i, Vector3 textSize)
    {
        i.transform.localScale = textSize;
        return i;
    }

    void MakeSelection()
    {
        switch (menuChoice)
        {
            case 1:
                LoadScene("CharacterSelect");
                break;

            case 2:
                StartCoroutine(CanvasFadeOut(mainCanvas));
                isMainVisible = false;

                StartCoroutine(CanvasFadeIn(howtoplayCanvas));
                howtoplayMenu.isVisible = true;
                break;

            case 3:
                StartCoroutine(CanvasFadeOut(mainCanvas));
                isMainVisible = false;

                StartCoroutine(CanvasFadeIn(optionsCanvas));
                optionsMenu.isVisible = true;
                break;

            case 4:
                Quit();
                break;
        }
    }

    //asynchronously loads the selected scene
    void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    void SetCanvas(Canvas canvasToFadeIn, Canvas canvasToFadeOut)
    {
        StartCoroutine(CanvasFadeIn(canvasToFadeIn));
        StartCoroutine(CanvasFadeOut(canvasToFadeOut));
    }

    //fades in the selected Canvas
    IEnumerator CanvasFadeIn(Canvas c)
    {
        CanvasGroup cg = c.GetComponent<CanvasGroup>();
        while (cg.alpha < 1)
        {
            cg.alpha += fadeSpeed;
            yield return null;
        }
    }

    //fades out the selected Canvas
    IEnumerator CanvasFadeOut(Canvas c)
    {
        CanvasGroup cg = c.GetComponent<CanvasGroup>();
        while (cg.alpha > 0)
        {
            cg.alpha -= fadeSpeed;
            yield return null;
        }
    }

    //quits the game
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}