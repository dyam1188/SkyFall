using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls game's main functions
//attached to Game -> Script Holder - Game
public class GameController : MonoBehaviour
{
    public Transform spawnTransform;

    private bool isPaused;

    void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = spawnTransform.position;
        player.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void Start()
    {
        //todo: wangs
    }

    void Update()
    {
        if (!isPaused)
        {
            Run(); 
        }
    }

    void Run()
    {
        //game stuffs
    }
}
