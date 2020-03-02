using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alquitran_Instantiate : MonoBehaviour
{
    public GameObject charco_alquitran;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(charco_alquitran, transform.position, charco_alquitran.transform.rotation);
    }
}
