using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 1.0f * Time.deltaTime); 
    }
}
