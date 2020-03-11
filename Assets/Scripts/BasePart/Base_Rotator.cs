using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Rotator : MonoBehaviour
{
    public bool LIGHT;
    void Update()
    {
        if (LIGHT)
        {
            transform.Rotate(Vector3.up * 16.0f * Time.deltaTime);
        } 
        else
        {
            transform.Rotate(Vector3.up * 1.0f * Time.deltaTime);
        }
        
    }
}
