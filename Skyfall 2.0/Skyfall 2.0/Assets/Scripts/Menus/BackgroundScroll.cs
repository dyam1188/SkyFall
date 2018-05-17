using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls background image movement
//attached to Main Menu -> Background 0, 1
public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private Vector3 scrollSpeed;

    [SerializeField]
    private Vector3 newLocation;
    
    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime);

        if (transform.position.x > -newLocation.x || transform.position.y < -newLocation.y)
        {
            transform.position = newLocation;
        }
    }
}
