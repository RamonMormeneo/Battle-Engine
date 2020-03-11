﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra_Collision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collider)
    {
        Debug.Log("HELLO??");
        if(collider.gameObject.tag == "Player")
        {
                collider.gameObject.GetComponent<Health>().currentHealth -= 15;
                collider.gameObject.GetComponent<Rigidbody>().AddForce(-collider.transform.forward * 2500.0f, ForceMode.Impulse);
                print("Ostia"); 
        }       
    }
}