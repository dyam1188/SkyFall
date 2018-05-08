using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main controller for the main menu
//attached to Scenes -> Main Menu -> Script Holder - Main Menu
public class MainMenu : MonoBehaviour
{
    int menuChoice = 1;                     //initialized to 1 because index 0 is the logo

    [SerializeField]
    private GameObject[] t_menu = new GameObject[5];

    [SerializeField]
    private GameObject[] t_howtoplay = new GameObject[1];

    [SerializeField]
    private GameObject[] t_options = new GameObject[1];

    private const float fadeSpeed = 0.05f;  //the rate at which objects fade in or out per frame

    //text stuff
    private Vector3 textSmall = new Vector3(1f, 1f, 1f);
    private Vector3 textLarge = new Vector3(1.25f, 1.25f, 1f);
    //private Vector3 textScale = new Vector3(0.25f, 0.25f, 0f);

    void Start()
    {
        //show menu text objects
        for (int i = 0; i < t_menu.Length; i++)
        {
            StartCoroutine("FadeIn", t_menu[i].GetComponent<SpriteRenderer>());
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
    }

    void Update()
    {
        GetKeyInput();
    }

    //controls main menu selection
    void GetKeyInput()
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
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(t_howtoplay[0].GetComponent<SpriteRenderer>().material.color.a);

            if (t_howtoplay[0].GetComponent<SpriteRenderer>().material.color.a > 0.5f)
            {
                for (int i = 0; i < t_howtoplay.Length; i++)
                {
                    StartCoroutine(FadeOut(t_howtoplay[i].GetComponent<SpriteRenderer>()));
                }

                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(FadeIn(t_menu[i].GetComponent<SpriteRenderer>()));
                }
            }

            if (t_options[0].GetComponent<SpriteRenderer>().material.color.a > 0.5f)
            {
                for (int i = 0; i < t_options.Length; i++)
                {
                    StartCoroutine(FadeOut(t_options[i].GetComponent<SpriteRenderer>()));
                }

                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(FadeIn(t_menu[i].GetComponent<SpriteRenderer>()));
                }
            }
        }
    }

    //scale the selected menu option larger
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

    //scale the selected text
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
                    StartCoroutine(FadeOut(t_menu[i].GetComponent<SpriteRenderer>()));
                }
                for (int i = 0; i < t_howtoplay.Length; i++)
                {
                    StartCoroutine(FadeIn(t_howtoplay[i].GetComponent<SpriteRenderer>()));
                }
                break;

            case 3:
                for (int i = 0; i < t_menu.Length; i++)
                {
                    StartCoroutine(FadeOut(t_menu[i].GetComponent<SpriteRenderer>()));
                }
                for (int i = 0; i < t_options.Length; i++)
                {
                    StartCoroutine(FadeIn(t_options[i].GetComponent<SpriteRenderer>()));
                }
                break;

            case 4:
                Quit();
                break;
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    //fades in the selected SpriteRenderer(s)
    IEnumerator FadeIn(SpriteRenderer sr)
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
    IEnumerator FadeOut(SpriteRenderer sr)
    {
        for (float alpha = 1f; alpha > 0f; alpha -= fadeSpeed)
        {
            Color c = sr.material.color;
            c.a = alpha;
            sr.material.color = c;
            yield return null;
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