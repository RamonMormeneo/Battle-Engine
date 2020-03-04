using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho_Col : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player") // Cuidado. 
        {
            Destroy(this.gameObject);
        }
    }
}
