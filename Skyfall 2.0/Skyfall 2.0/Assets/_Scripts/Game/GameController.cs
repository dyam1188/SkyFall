using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls game's main functions
//attached to Level# -> Script Holder - Game
public class GameController : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject blackScreen;

    [SerializeField]
    GameObject pauseMenuController;

    public bool isPaused;

    void Start()
    {
        StartCoroutine(FadeInScene());
        InitializePlayer();
    }

    IEnumerator FadeInScene()
    {
        float alpha = 1;
        while (blackScreen.GetComponent<SpriteRenderer>().material.color.a >= 0)
        {
            alpha -= 0.01f;
            blackScreen.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    //sets player's starting transform
    //this is needed because the player is passed from the Character Select scene with DontDestroyOnLoad()
    void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = transform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void Update()
    {
        GetKeyInput();
        CheckPauseState();
    }

    void GetKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            isPaused = isPaused ? false : true;
        }
    }

    //?: operators are useful
    void CheckPauseState()
    {
        Time.timeScale = isPaused ? 0 : 1;
        player.GetComponent<PlayerController>().inputEnabled = isPaused ? false : true;

        pauseMenuController.gameObject.SetActive(isPaused ? true : false);
    }
}
