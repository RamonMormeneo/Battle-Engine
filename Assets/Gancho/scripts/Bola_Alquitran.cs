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
        if (inside) return;
        //gameObject.GetComponent<player_movement>().speed = 5;
        else return;
        //gameObject.GetComponent<player_movement>().speed = original_Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Alquitran")
            inside = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Alquitran")
            inside = false;
    }

}
