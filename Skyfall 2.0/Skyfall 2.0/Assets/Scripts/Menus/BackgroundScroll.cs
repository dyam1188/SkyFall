using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls background image movement
//attached to Main Menu -> Background 0, 1
public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private Vector3 newLocation;
    private Vector3 scrollSpeed;

    void Start()
    {
        scrollSpeed = new Vector3(1f, 0f, 0f);
    }

    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime);

        if (transform.position.x > newLocation.x * -1)
        {
            transform.position = newLocation;
        }
    }
}
