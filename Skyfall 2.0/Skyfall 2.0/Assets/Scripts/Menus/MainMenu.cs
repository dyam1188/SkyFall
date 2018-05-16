using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//main controller for Main Menu
//attached to Script Holder - Main Menu
public class MainMenu : MonoBehaviour
{
    private bool isMainVisible = true;
    private int menuChoice = 1;                     //initialized to 1 because index 0 is the logo

    [SerializeField]
    private Canvas mainCanvas;
    private CanvasGroup mainCanvasGroup;

    [SerializeField]
    private Image[] menuText = new Image[5];

    [Space]

    [SerializeField]
    private Canvas howtoplayCanvas;
    private CanvasGroup howtoplayCanvasGroup;
    public HowToPlayMenu howtoplayMenu;

    [Space]

    [SerializeField]
    private Canvas optionsCanvas;
    private CanvasGroup optionsCanvasGroup;
    public OptionsMenu optionsMenu;

    private const float fadeSpeed = 0.1f;  //the rate at which objects fade in or out per frame

    //text sizes
    private Vector3 textSmall = new Vector3(1f, 1f, 1f);
    private Vector3 textLarge = new Vector3(1.25f, 1.25f, 1f);

    void Start()
    {
        mainCanvasGroup = mainCanvas.GetComponent<CanvasGroup>();
        howtoplayCanvasGroup = howtoplayCanvas.GetComponent<CanvasGroup>();
        optionsCanvasGroup = optionsCanvas.GetComponent<CanvasGroup>();

        StartCoroutine(CanvasFadeIn(mainCanvas));

        //set default menu choice
        menuText[menuChoice].rectTransform.localScale = textLarge;

        //set howtoplay canvas alpha to 0
        howtoplayCanvasGroup.alpha = 0;

        //set options canvas alpha to 0
        optionsCanvasGroup.alpha = 0;
    }

    void Update()
    {
        GetKeyInput();
        CheckCanvasVisible(mainCanvasGroup);
        CheckCanvasVisible(howtoplayCanvasGroup);
        CheckCanvasVisible(optionsCanvasGroup);
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

            else if (howtoplayMenu.isVisible && howtoplayMenu.menuChoice == howtoplayMenu.howtoplayText.Length - 1)
            {
                StartCoroutine(SetCanvas(mainCanvas, howtoplayCanvas));
                isMainVisible = true;
                howtoplayMenu.isVisible = false;
            }

            else if (optionsMenu.isVisible && optionsMenu.menuChoice == optionsMenu.optionsText.Length - 1)
            {
                StartCoroutine(SetCanvas(mainCanvas, optionsCanvas));
                isMainVisible = true;
                optionsMenu.isVisible = false;
            }
        }

        if (!isMainVisible && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape)))
        {
            if (howtoplayMenu.isVisible)
            {
                StartCoroutine(SetCanvas(mainCanvas, howtoplayCanvas));
                isMainVisible = true;
                howtoplayMenu.isVisible = false;
            }

            if (optionsMenu.isVisible)
            {
                StartCoroutine(SetCanvas(mainCanvas, optionsCanvas));
                isMainVisible = true;
                optionsMenu.isVisible = false;
            }
        }
    }

    bool CheckCanvasVisible(CanvasGroup cg)
    {
        bool isVisible;

        if (cg.alpha == 0)
        {
            isVisible = false;
        }
        else
        {
            isVisible = true;
        }

        return isVisible;
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
                StartCoroutine(SetCanvas(howtoplayCanvas, mainCanvas));
                isMainVisible = false;
                howtoplayMenu.isVisible = true;
                break;

            case 3:
                StartCoroutine(SetCanvas(optionsCanvas, mainCanvas));
                isMainVisible = false;
                optionsMenu.isVisible = true;
                optionsMenu.menuChoice = 0;
                optionsMenu.ResizeText();
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

    //changes the canvas
    IEnumerator SetCanvas(Canvas canvasToFadeIn, Canvas canvasToFadeOut)
    {
        StartCoroutine(CanvasFadeOut(canvasToFadeOut));
        yield return new WaitForSeconds((1 / fadeSpeed) * Time.deltaTime);
        StartCoroutine(CanvasFadeIn(canvasToFadeIn));
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