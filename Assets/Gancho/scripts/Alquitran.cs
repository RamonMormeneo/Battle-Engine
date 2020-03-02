using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alquitran : MonoBehaviour
{
    //public GameObject alquitran; //Highpoly model area in the floor. Esto en el disparo. 
    private bool inside = false;
    private float original_Speed; //Velocidad original. 

    private void Start()
    {
        //original_Speed = gameObject.GetComponent<player_movement>().speed
    }

    void Update()
    {
        //Si esta activado, slow..
        //Cambiar velocidad de la base, a una definida: 5 
        if (inside)
        {
            gameObject.GetComponent<Movement>().speed_multiply = 1;
            gameObject.GetComponent<Movement>().maxSpeed = 10;
            print("INSIDE");
        }
        else
        {
            gameObject.GetComponent<Movement>().speed_multiply = 3;
            gameObject.GetComponent<Movement>().maxSpeed = 35;
        }
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Alquitran")
        {
            inside = true;
        }
           
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Alquitran")
        {
            inside = false;
            //gameObject.GetComponent<Movement>().speed = 3;
            ///Salir del alquitran
            //print(gameObject.GetComponent<Movement>().speed);
        }
           
    }
}
