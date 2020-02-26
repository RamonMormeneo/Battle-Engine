using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEM : MonoBehaviour
{
    //ESTE CODIGO VA EN LA TORRETA.

    //Lanzar una bola PEM, que inutiliza al enemigo durante 1 s. 
    //Objectos: 1 Lanzamiento de torreto. 2 Bola PEM con efecto. 

    public GameObject Bola_PEM; //Objeto prefab BOLA PEM.
    public GameObject punto_Torreta; //Objeto que define de donde salen las balas. 
    public float F; //Fuerza con la que sale la bala. 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj = Instantiate(Bola_PEM, punto_Torreta.transform.position, Bola_PEM.transform.rotation); // Instanciar tiro.
            obj.GetComponent<Rigidbody>().AddForce(transform.forward * F, ForceMode.Impulse);
        }
    }
}
