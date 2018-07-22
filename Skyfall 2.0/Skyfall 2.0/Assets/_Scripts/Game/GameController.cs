using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//controls game's main functions
//attached to Level# -> Script Holder - Game
public class GameController : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject pauseMenu;

    public bool isPaused;

    void Start()
    {
        InitializePlayer();
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
        pauseMenu.SetActive(isPaused ? true : false);
    }

    void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
