using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//main controller for Character Select
//attached to Character Select -> Script Holder - Character Select
public class CharacterSelect : MonoBehaviour
{
    private int playerChoice = 0;

    [SerializeField]
    private GameObject[] s_players = new GameObject[4];

    [Space]

    [SerializeField]
    private GameObject selection;
    private SpriteRenderer srSelection;

    private const float minFade = 0.25f;
    private const float maxFade = 1.00f;
    private float fadeSpeed = 0.01f;

    void Start()
    {
        srSelection = selection.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetKeyInput();
        StartCoroutine(FadeOut(srSelection));
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerChoice != 0)
        {
            playerChoice--;
            selection.transform.position = s_players[playerChoice].transform.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && playerChoice != s_players.Length)
        {
            playerChoice++;
            selection.transform.position = s_players[playerChoice].transform.position;
        }
    }

    IEnumerator FadeOut(SpriteRenderer sr)
    {
        for (float alpha = maxFade; alpha > minFade; alpha -= fadeSpeed)
        {
            Color c = sr.material.color;
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
        StartCoroutine(FadeIn(srSelection));
    }

    IEnumerator FadeIn(SpriteRenderer sr)
    {
        for (float alpha = minFade; alpha < maxFade; alpha += fadeSpeed)
        {
            Color c = sr.material.color;
            c.a = alpha;
            sr.material.color = c;
            yield return null;
        }
        StartCoroutine(FadeOut(srSelection));
    }
}