﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main controller for Character Select
//attached to Character Select -> Script Holder - Character Select
public class CharacterSelect : MonoBehaviour
{
    public int menuChoice = 0;

    public GameObject[] players = new GameObject[4];
    private SpriteRenderer[] playersSprite = new SpriteRenderer[4];

    private const float fadeSpeed = 0.1f;
    private const float moveSpeed = 0.1f;
    private float left, middle, right;

    private bool keyInputEnabled = true;

    void Start()
    {
        middle = -4;
        left = middle - 2;
        right = middle + 2;

        for (int i = 0; i < players.Length; i++)
        {
            playersSprite[i] = players[i].GetComponent<SpriteRenderer>();
            if (i != menuChoice)
            {
                playersSprite[i].material.color = new Color (1, 1, 1, 0);
            }
        }
    }

    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }
    }

    //moves the selected gameobject left
    IEnumerator MoveLeft(Transform t, float from, float to)
    {
        for (float x = from; x >= to; x -= moveSpeed)
        {
            Move(t, x);
            yield return null;
        }
    }

    //moves the selected gameobject right
    IEnumerator MoveRight(Transform t, float from, float to)
    {
        for (float x = from; x <= to; x += moveSpeed)
        {
            Move(t, x);
            yield return null;
        }
    }

    //controls the movement
    void Move(Transform t, float x)
    {
        x = Mathf.Round(x * 10) / 10;
        t.position = new Vector3(x, t.position.y, t.position.z);
    }

    //fades out the selected sprite
    IEnumerator FadeOut(SpriteRenderer sr)
    {
        keyInputEnabled = false;
        for (float a = 1f; a >= 0 - fadeSpeed; a -= fadeSpeed)
        {
            Fade(sr, a);
            yield return null;
        }
    }

    //fades in the selected sprite
    IEnumerator FadeIn(SpriteRenderer sr)
    {
        for (float a = 0f; a <= 1 + fadeSpeed; a += fadeSpeed)
        {
            Fade(sr, a);
            yield return null;
        }
        keyInputEnabled = true;
    }

    //controls the fade
    void Fade(SpriteRenderer sr, float alpha)
    {
        Color c = sr.material.color;
        alpha = Mathf.Round(alpha * (1 / fadeSpeed)) / (1 / fadeSpeed);
        c.a = alpha;
        sr.material.color = c;
    }
}