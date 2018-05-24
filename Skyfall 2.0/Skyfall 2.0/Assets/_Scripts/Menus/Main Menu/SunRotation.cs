using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls sun image rotation
//attached to Main Menu -> Sun
public class SunRotation : MonoBehaviour
{
    private Vector3 sunRotation = new Vector3(0f, 0f, -0.1f);

    void Update()
    {
        transform.Rotate(sunRotation);
    }

}
