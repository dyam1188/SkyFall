using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//main controller for Character Select
//attached to CharacterSelect -> Script Holder - Character Select
public class CharacterSelect : MonoBehaviour
{
    bool inputEnabled = true;

    public int choice = 0;

    public GameObject[] players = new GameObject[4];
    SpriteRenderer[] playersSprite = new SpriteRenderer[4];

    const float fadeSpeed = 0.1f;
    const float scrollSpeed = 0.1f;
    float left, middle, right;

    void Start()
    {
        middle = players[0].transform.position.x;
        left = middle - 2;
        right = middle + 2;

        for (int i = 0; i < players.Length; i++)
        {
            playersSprite[i] = players[i].GetComponent<SpriteRenderer>();
            if (i != choice)
            {
                playersSprite[i].material.color = new Color(1, 1, 1, 0);
            }
        }
    }

    void Update()
    {
        if (inputEnabled)
        {
            GetKeyInput();
        }
    }

    void GetKeyInput()
    {
        //there has to be a better way to do this
        if (Input.GetKeyDown(KeyCode.LeftArrow) && choice != 0)
        {
            StartCoroutine(FadeOut(playersSprite[choice]));
            StartCoroutine(MoveRight(players[choice].GetComponent<Transform>(), middle, right));

            choice--;

            StartCoroutine(FadeIn(playersSprite[choice]));
            StartCoroutine(MoveRight(players[choice].GetComponent<Transform>(), left, middle));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && choice != players.Length - 1)
        {
            StartCoroutine(FadeOut(playersSprite[choice]));
            StartCoroutine(MoveLeft(players[choice].GetComponent<Transform>(), middle, left));

            choice++;

            StartCoroutine(FadeIn(playersSprite[choice]));
            StartCoroutine(MoveLeft(players[choice].GetComponent<Transform>(), right, middle));
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
        {
            SelectCharacter();
            LoadScene("Game");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadScene("Main Menu");
        }
    }

    void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    void SelectCharacter()
    {
        //carry over selected character to the game scene
        GameObject selection = players[choice];
        DontDestroyOnLoad(selection);

        //enable all components (scripts, collider, etc.)
        foreach (Behaviour b in selection.GetComponents<Behaviour>())
        {
            b.enabled = true;
        }
    }

    //scrolls the characters left
    IEnumerator MoveLeft(Transform t, float from, float to)
    {
        for (float x = from; x >= to; x -= scrollSpeed)
        {
            Move(t, x);
            yield return null;
        }
    }

    //"" right
    IEnumerator MoveRight(Transform t, float from, float to)
    {
        for (float x = from; x <= to; x += scrollSpeed)
        {
            Move(t, x);
            yield return null;
        }
    }

    //controls scrolling
    void Move(Transform t, float x)
    {
        x = Mathf.Round(x * 10) / 10;
        t.position = new Vector3(x, t.position.y, t.position.z);
    }

    //fades the character sprite out
    IEnumerator FadeOut(SpriteRenderer sr)
    {
        inputEnabled = false;
        for (float a = 1f; a >= 0 - fadeSpeed; a -= fadeSpeed)
        {
            Fade(sr, a);
            yield return null;
        }
        sr.gameObject.SetActive(false);
    }

    //"" in
    IEnumerator FadeIn(SpriteRenderer sr)
    {
        sr.gameObject.SetActive(true);
        for (float a = 0f; a <= 1 + fadeSpeed; a += fadeSpeed)
        {
            Fade(sr, a);
            yield return null;
        }
        inputEnabled = true;
    }

    //controls fade
    void Fade(SpriteRenderer sr, float alpha)
    {
        alpha = Mathf.Round(alpha * (1 / fadeSpeed)) / (1 / fadeSpeed);
        sr.material.color = new Color(1, 1, 1, alpha);
    }
}