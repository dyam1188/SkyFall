using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls game's main functions
//attached to Level# -> Script Holder - Game
public class GameController : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject blackScreen;

    public bool isPaused;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        SetPosition();
    }

    //sets player's starting transform
    //this is needed because the player is passed from the Character Select scene with DontDestroyOnLoad()
    void SetPosition()
    {
        player.transform.position = transform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void Update()
    {
        UpdatePauseState();
        CheckPauseState();
    }

    //things to change when paused
    void UpdatePauseState()
    {
        PlayerController pc = player.GetComponent<PlayerController>();

        if (isPaused)
        {
            pc.inputEnabled = false;
            Time.timeScale = 0;
            blackScreen.GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 0, 0.7f);
            GetComponent<PauseMenu>().enabled = true;
        }
        else
        {
            pc.inputEnabled = true;
            Time.timeScale = 1;
            blackScreen.GetComponent<SpriteRenderer>().material.color = new Color(0, 0, 0, 0);
            GetComponent<PauseMenu>().enabled = false;
        }
    }

    void CheckPauseState()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            isPaused = isPaused ? false : true;
        }
    }
}
