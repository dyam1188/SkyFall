using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls game's main functions
//attached to Game -> Script Holder - Game
public class GameController : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private Canvas optionsMenu;

    [SerializeField]
    private SpriteRenderer blackBG;

    public bool isPaused;

    void Start()
    {
        InitializePlayer();
        blackBG.material.color = new Color(1, 1, 1, 0);
    }

    //sets player's starting transform
    //this is needed because the player is passed from the Character Select scene through DontDestroyOnLoad()
    void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = transform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void Update()
    {
        CheckState();
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

    //?: operators are useful ^_^
    void SetPaused()
    {
        isPaused = isPaused ? false : true;
        Time.timeScale = isPaused ? 0 : 1;
        player.GetComponent<PlayerController>().inputEnabled = isPaused ? false : true;

        float alpha = isPaused ? 0.7f : 0f;
        blackBG.material.color = new Color(1, 1, 1, alpha);
        //optionsMenu.GetComponent<CanvasGroup>().alpha = isPaused ? 0 : 1;
    }
}
