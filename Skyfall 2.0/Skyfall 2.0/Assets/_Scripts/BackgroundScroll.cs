using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls background image movement
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
