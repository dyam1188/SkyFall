using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//main controller for Main Menu
//attached to Main Menu -> Script Holder - Main Menu
public class MainMenu : MonoBehaviour
{
    //private bool isMainVisible = true;
    private bool inputEnabled = true;
    private int menuChoice = 1;                     //initialized to 1 because index 0 is the logo

    [SerializeField]
    private Image[] menuText = new Image[5];

    [SerializeField]
    private Canvas mainCanvas;

    [Space]

    [SerializeField]
    private Canvas howtoplayCanvas;
    public HowToPlayMenu howtoplayMenu;

    [Space]

    [SerializeField]
    private Canvas optionsCanvas;
    public OptionsMenu optionsMenu;

    private const float fadeSpeed = 0.1f;  //the rate at which objects fade in or out per frame

    //text sizes
    private Vector3 textSmall = new Vector3(1f, 1f, 1f);
    private Vector3 textLarge = new Vector3(1.25f, 1.25f, 1f);

    void Start()
    {
        StartCoroutine(CanvasFadeIn(mainCanvas));

        //set default menu choice
        menuText[menuChoice].rectTransform.localScale = textLarge;

        //set howtoplay canvas alpha to 0
        howtoplayCanvas.gameObject.SetActive(false);

        //set options canvas alpha to 0
        optionsCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (inputEnabled)
        {
            GetKeyInput();
        }
    }

    //controls main menu selection
    void GetKeyInput()
    {
        //Up/Down - change menu choice
        if (mainCanvas.gameObject.activeSelf)
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

        //X/Space - displays howtoplay or options canvas
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
        {
            if (mainCanvas.gameObject.activeSelf)
            {
                MakeSelection();
            }

            else if (howtoplayCanvas.gameObject.activeSelf && howtoplayMenu.menuChoice == howtoplayMenu.howtoplayText.Length - 1)
            {
                StartCoroutine(SetCanvas(mainCanvas, howtoplayCanvas));
            }

            else if (optionsCanvas.gameObject.activeSelf && optionsMenu.menuChoice == optionsMenu.optionsText.Length - 1)
            {
                StartCoroutine(SetCanvas(mainCanvas, optionsCanvas));
            }
        }

        //Z - displays the main menu
        if (!mainCanvas.gameObject.activeSelf && (Input.GetKeyDown(KeyCode.Z)))
        {
            if (howtoplayMenu.gameObject.activeSelf)
            {
                StartCoroutine(SetCanvas(mainCanvas, howtoplayCanvas));
            }

            if (optionsMenu.gameObject.activeSelf)
            {
                StartCoroutine(SetCanvas(mainCanvas, optionsCanvas));
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
                StartCoroutine(SetCanvas(howtoplayCanvas, mainCanvas));
                break;

            case 3:
                StartCoroutine(SetCanvas(optionsCanvas, mainCanvas));
                optionsMenu.menuChoice = 0;
                optionsMenu.ResizeText();
                break;

            case 4:
                Quit();
                break;
        }
    }

    //asynchronously loads the selected scene
    public void LoadScene(string sceneName)
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

    //fades out the selected Canvas
    IEnumerator CanvasFadeOut(Canvas c)
    {
        inputEnabled = false;

        CanvasGroup cg = c.GetComponent<CanvasGroup>();
        while (cg.alpha > 0)
        {
            cg.alpha -= fadeSpeed;
            yield return null;
        }

        c.gameObject.SetActive(false);
    }

    //fades in the selected Canvas
    IEnumerator CanvasFadeIn(Canvas c)
    {
        c.gameObject.SetActive(true);

        CanvasGroup cg = c.GetComponent<CanvasGroup>();
        while (cg.alpha < 1)
        {
            cg.alpha += fadeSpeed;
            yield return null;
        }

        inputEnabled = true;
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