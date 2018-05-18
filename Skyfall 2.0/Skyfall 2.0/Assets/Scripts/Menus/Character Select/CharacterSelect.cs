using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main controller for Character Select
//attached to Character Select -> Script Holder - Character Select
public class CharacterSelect : MonoBehaviour
{
    private int menuChoice = 0;

    [SerializeField]
    private GameObject leftArrow, rightArrow;

    [Space]

    [SerializeField]
    private GameObject[] players = new GameObject[4];
    private SpriteRenderer[] playersSprite = new SpriteRenderer[4];

    [SerializeField]
    private Transform playerCenterpoint;

    private float left, middle, right;
    private const float fadeSpeed = 0.1f;
    private const float moveSpeed = 0.1f;
    private const float rotateSpeed = 3f;

    private Color invisible = new Color(1, 1, 1, 0);
    private Color visible = new Color(1, 1, 1, 1);

    private bool keyInputEnabled = true;

    void Start()
    {
        middle = -4;
        left = -6;
        right = -2;

        for (int i = 0; i < players.Length; i++)
        {
            playersSprite[i] = players[i].GetComponent<SpriteRenderer>();
            if (i != menuChoice)
            {
                playersSprite[i].material.color = invisible;
            }
        }
    }

    void Update()
    {
        ShowArrows();
        if (keyInputEnabled)
        {
            GetKeyInput();
        }
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && menuChoice != 0)
        {
            StartCoroutine(FadeOut(playersSprite[menuChoice]));
            StartCoroutine(MoveRight(players[menuChoice].GetComponent<Transform>(), middle, right));

            menuChoice--;

            StartCoroutine(FadeIn(playersSprite[menuChoice]));
            StartCoroutine(MoveRight(players[menuChoice].GetComponent<Transform>(), left, middle));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && menuChoice != players.Length - 1)
        {
            StartCoroutine(FadeOut(playersSprite[menuChoice]));
            StartCoroutine(MoveLeft(players[menuChoice].GetComponent<Transform>(), middle, left));

            menuChoice++;

            StartCoroutine(FadeIn(playersSprite[menuChoice]));
            StartCoroutine(MoveLeft(players[menuChoice].GetComponent<Transform>(), right, middle));
        }
    }

    void ShowArrows()
    {
        if (menuChoice == 0)
        {
            leftArrow.GetComponent<SpriteRenderer>().color = invisible;
        }
        else if (menuChoice == players.Length - 1)
        {
            rightArrow.GetComponent<SpriteRenderer>().color = invisible;
        }
        else
        {
            leftArrow.GetComponent<SpriteRenderer>().color = visible;
            rightArrow.GetComponent<SpriteRenderer>().color = visible;
        }
    }

    /*void UpdateSelection(SpriteRenderer sr, Transform t, int menuChangeAmount, )
    {

        StartCoroutine(FadeOut(sr));
        StartCoroutine();
        menuChoice += menuChangeAmount;
        StartCoroutine(FadeIn(sr));
        StartCoroutine();

    }*/


    IEnumerator MoveLeft(Transform t, float from, float to)
    {
        for (float x = from; x >= to; x -= moveSpeed)
        {
            x = Mathf.Round(x * 10) / 10;
            t.position = new Vector3(x, t.position.y, t.position.z);
            yield return null;
        }
    }

    IEnumerator MoveRight(Transform t, float from, float to)
    {
        for (float x = from; x <= to; x += moveSpeed)
        {
            x = Mathf.Round(x * 10) / 10;
            t.position = new Vector3(x, t.position.y, t.position.z);
            yield return null;
        }
    }

    //I CAN'T GET IT TO WORK AAAAAAA
    /*IEnumerator Fade(SpriteRenderer sr, float start, float end, bool direction)
    {
        for (float i = start; i <= end; i += fadeSpeed)
        {
            //float j = direction ? i : (end - fadeSpeed) - i;
            Color c = sr.material.color;
            i = Mathf.Round(i * (1 / fadeSpeed)) / (1 / fadeSpeed);
            c.a = i;
            sr.material.color = c;
            Debug.Log(i);
            yield return null;
        }
    }*/

    IEnumerator FadeOut(SpriteRenderer sr)
    {
        keyInputEnabled = false;
        for (float alpha = 1f; alpha >= 0f; alpha -= fadeSpeed)
        {
            Color c = sr.material.color;
            alpha = Mathf.Round(alpha * (1 / fadeSpeed)) / (1 / fadeSpeed);
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
    }

    IEnumerator FadeIn(SpriteRenderer sr)
    {
        for (float alpha = 0f; alpha <= 1f; alpha += fadeSpeed)
        {
            Color c = sr.material.color;
            alpha = Mathf.Round(alpha * (1 / fadeSpeed)) / (1 / fadeSpeed);
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
        keyInputEnabled = true;
    }
}