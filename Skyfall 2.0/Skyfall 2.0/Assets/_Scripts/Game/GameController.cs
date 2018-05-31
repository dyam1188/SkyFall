using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls game's main functions
//attached to Game -> Script Holder - Game
public class GameController : MonoBehaviour
{
    [SerializeField]
    private Transform spawnTransform;

    [SerializeField]
    private Canvas optionsMenu;

    public bool isPaused;

    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = spawnTransform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void Start()
    {

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

        //show pause menu
        if (isPaused)
        {
            
        }
    }

    void SetPaused()
    {
        isPaused = isPaused ? false : true;
        Time.timeScale = isPaused ? 0 : 1;
        optionsMenu.GetComponent<CanvasGroup>().alpha = isPaused ? 0 : 1;
    }
}
