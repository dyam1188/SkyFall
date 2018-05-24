using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Transform spawnTransform;


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

    }
}
