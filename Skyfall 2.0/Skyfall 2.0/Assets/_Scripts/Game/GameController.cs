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
        DisablePauseMenu();
    }

    //sets player's starting transform
    //this is needed because the player is passed from the Character Select scene through DontDestroyOnLoad()
    void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = transform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void DisablePauseMenu()
    {
        foreach (Behaviour b in pauseMenu.GetComponents<Behaviour>())
        {
            b.enabled = false;
        }
    }

    void Update()
    {
        CheckState();
        DebugStuff();
    }

    //game stuffs
    void CheckState()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            SetPaused();
        }
        //add more stuff later
    }

    //?: operators are useful
    void SetPaused()
    {
        isPaused = isPaused ? false : true;
        Time.timeScale = isPaused ? 0 : 1;
        player.GetComponent<PlayerController>().inputEnabled = isPaused ? false : true;
        foreach (Behaviour b in pauseMenu.GetComponents<Behaviour>())
        {
            b.enabled = isPaused ? true : false;
        }
    }

    void DebugStuff()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
