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
    private GameObject[] players = new GameObject[4];
    private SpriteRenderer[] playersSprite = new SpriteRenderer[4];

    private float left, middle, right;
    private const float fadeSpeed = 0.1f;
    private const float moveSpeed = 0.1f;

    void Start()
    {
        middle = 0f;
        left = -moveSpeed * 20;
        right = moveSpeed * 20;

        for (int i = 0; i < players.Length; i++)
        {
            playersSprite[i] = players[i].GetComponent<SpriteRenderer>();
            if (i != menuChoice)
            {
                playersSprite[i].material.color = new Color(1, 1, 1, 0);
            }
        }
    }

    void Update()
    {
        GetKeyInput();
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

    IEnumerator MoveLeft(Transform t, float from, float to)
    {
        for (float x = from; x >= to; x -= moveSpeed)
        {
            x = Mathf.Round(x * 10) / 10;
            t.position = new Vector3 (x, t.position.y, t.position.z);
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

    IEnumerator FadeOut(SpriteRenderer sr)
    {
        for (float alpha = 1f; alpha >= 0f; alpha -= fadeSpeed)
        {
            Color c = sr.material.color;
            alpha = Mathf.Round(alpha * 10) / 10;       
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
            alpha = Mathf.Round(alpha * 10) / 10;
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
    }
}