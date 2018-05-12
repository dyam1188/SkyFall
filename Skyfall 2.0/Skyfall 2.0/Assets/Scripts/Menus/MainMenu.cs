using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main controller for Main Menu
//attached to Main Menu -> Script Holder - Main Menu
public class MainMenu : MonoBehaviour
{
    public OptionsMenu optionsMenu;

    private int menuChoice = 1;                     //initialized to 1 because index 0 is the logo
    private bool isMenuVisible = true;

    [SerializeField]
    private GameObject[] t_menu = new GameObject[5];

    [SerializeField]
    private GameObject[] t_howtoplay = new GameObject[1];

    [SerializeField]
    private GameObject[] t_options = new GameObject[1];

	[SerializeField]
	private Canvas c_options;

    private const float fadeSpeed = 0.05f;  //the rate at which objects fade in or out per frame

    //text sizes
    private Vector3 textSmall = new Vector3(1f, 1f, 1f);
    private Vector3 textLarge = new Vector3(1.25f, 1.25f, 1f);

    void Start()
    {
        //show menu text objects
        for (int i = 0; i < t_menu.Length; i++)
        {
            StartCoroutine(TextFadeIn(t_menu[i].GetComponent<SpriteRenderer>()));
        }

        //hide how to play text objects
        for (int i = 0; i < t_howtoplay.Length; i++)
        {
            Color c = t_howtoplay[i].GetComponent<SpriteRenderer>().material.color;
            c.a = 0f;
            t_howtoplay[i].GetComponent<SpriteRenderer>().material.color = c;
        }

        //hide options text objects
        for (int i = 0; i < t_options.Length; i++)
        {
            Color c = t_options[i].GetComponent<SpriteRenderer>().material.color;
            c.a = 0f;
            t_options[i].GetComponent<SpriteRenderer>().material.color = c;
        }

        //set default menu choice
        t_menu[menuChoice].transform.localScale = textLarge;

        //set default canvas alpha to 0
        c_options.GetComponent<CanvasGroup>().alpha = 0;
    }

    void Update()
    {
        GetKeyInput();
    }

    //controls main menu selection
    void GetKeyInput()
    {
        if (isMenuVisible)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && menuChoice != 1)
            {
                menuChoice--;
                ResizeText();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && menuChoice != t_menu.Length - 1)
            {
                menuChoice++;
                ResizeText();
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
            {
                MakeSelection();
                isMenuVisible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape))
        {
            //change below line after making the howtoplay menu
            if (t_howtoplay[0].GetComponent<SpriteRenderer>().material.color.a > 0.5f)
            {
                for (int i = 0; i < t_howtoplay.Length; i++)
                {
                    StartCoroutine(TextFadeOut(t_howtoplay[i].GetComponent<SpriteRenderer>()));
                }

                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(TextFadeIn(t_menu[i].GetComponent<SpriteRenderer>()));
                }
            }

            if (optionsMenu.isVisible)
            {
                for (int i = 0; i < t_options.Length; i++)
                {
                    StartCoroutine(TextFadeOut(t_options[i].GetComponent<SpriteRenderer>()));
					StartCoroutine(CanvasFadeOut(c_options));
				}

                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(TextFadeIn(t_menu[i].GetComponent<SpriteRenderer>()));
                }
            }

            isMenuVisible = true;
        }
    }

    //scales the selected menu option larger
    void ResizeText()
    {
        for (int i = 1; i < t_menu.Length; i++)
        {
            if (i == menuChoice)
            {
                SetText(t_menu[i], textLarge);
            }
            else
            {
                SetText(t_menu[i], textSmall);
            }
        }
    }

    //scales the selected text
    GameObject SetText(GameObject go, Vector3 textSize)
    {
        go.transform.localScale = textSize;
        return go;
    }

    void MakeSelection()
    {
        switch (menuChoice)
        {
            case 1:
                LoadScene("CharacterSelect");
                break;

            case 2:
                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(TextFadeOut(t_menu[i].GetComponent<SpriteRenderer>()));
                }
                for (int i = 0; i < t_howtoplay.Length; i++)
                {
                    StartCoroutine(TextFadeIn(t_howtoplay[i].GetComponent<SpriteRenderer>()));
                }
                break;

            case 3:
                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(TextFadeOut(t_menu[i].GetComponent<SpriteRenderer>()));
                }
                for (int i = 0; i < t_options.Length; i++)
                {
                    StartCoroutine(TextFadeIn(t_options[i].GetComponent<SpriteRenderer>()));
                }
                StartCoroutine(CanvasFadeIn(c_options));
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

    //fades in the selected SpriteRenderer(s)
    IEnumerator TextFadeIn(SpriteRenderer sr)
    {
        for (float alpha = 0f; alpha < 1f; alpha += fadeSpeed)
        {
            Color c = sr.material.color;
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
        
    }

    //fades out the selected SpriteRenderer(s)
    IEnumerator TextFadeOut(SpriteRenderer sr)
    {
        for (float alpha = 1f; alpha > 0f; alpha -= fadeSpeed)
        {
            Color c = sr.material.color;
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
    }

	//fades in the selected Canvas
	IEnumerator CanvasFadeIn(Canvas c)
	{
		CanvasGroup cg = c.GetComponent<CanvasGroup> ();
		while (cg.alpha < 1) {
			cg.alpha += fadeSpeed;
			yield return null;
		}

		cg.interactable = true;
		yield return null;
	}

	//fades out the selected Canvas
	IEnumerator CanvasFadeOut(Canvas c)
	{
		CanvasGroup cg = c.GetComponent<CanvasGroup> ();
		while (cg.alpha > 0) {
			cg.alpha -= fadeSpeed;
			yield return null;
		}

		cg.interactable = false;
		yield return null;
	}

    //quits the app
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}