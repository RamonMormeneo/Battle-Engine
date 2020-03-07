﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{

    public bool EnLlamas = false;

    private void Update()
    { 
        if(EnLlamas)
            gameObject.GetComponent<Health>().currentHealth -= 1;       
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Llamarada")
        {
            EnLlamas = true;
        } 
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Llamarada")
        {
            EnLlamas = false;
        }
    }
}
