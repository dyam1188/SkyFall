using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls game's main functions
//attached to Game -> Script Holder - Game
public class GameController : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private Transform spawnTransform;

    [SerializeField]
    private Canvas optionsMenu;

    public bool isPaused;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = spawnTransform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void Update()
    {
        Run();
    }

    //game stuffs
    void Run()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPaused();
        }
    }

    void SetPaused()
    {
        isPaused = isPaused ? false : true;
        Time.timeScale = isPaused ? 0 : 1;
        player.GetComponent<PlayerController>().inputEnabled = isPaused ? false : true;
        //optionsMenu.GetComponent<CanvasGroup>().alpha = isPaused ? 0 : 1;
    }
}
