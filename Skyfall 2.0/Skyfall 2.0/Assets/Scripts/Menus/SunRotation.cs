using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private Vector3 sunRotation = new Vector3(0f, 0f, -0.1f);

    void Update()
    {
        transform.Rotate(sunRotation);
    }

}
