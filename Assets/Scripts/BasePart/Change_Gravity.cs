using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Gravity : MonoBehaviour
{

    void FixedUpdate()
    {
        Physics.gravity = new Vector3(0.0f, -(9.81f*4), 0.0f);
    }
}
