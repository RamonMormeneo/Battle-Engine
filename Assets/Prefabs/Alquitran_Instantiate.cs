using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class Alquitran_Instantiate : MonoBehaviour
{
    public GameObject charco_alquitran;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            GameObject suelo =PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Alquitran_Suelo"), transform.position, charco_alquitran.transform.rotation);
            Destroy(suelo, 6.0f);
        }
    }
}
