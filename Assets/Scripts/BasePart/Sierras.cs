using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierras : MonoBehaviour
{
    public bool Activated = false;
    void Update()
    {
        if(Activated)
        {
            //1. Rotate:     
            transform.Rotate(Vector3.up * 2.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Hacer daño al enemigo. 
            //Empujarle con una fuerza. 
            collision.gameObject.GetComponent<Health>().currentHealth -= 30;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 30.0f, ForceMode.Impulse);
            print("OSTIA");
        }
    }
}
