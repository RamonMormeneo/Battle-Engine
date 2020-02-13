using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetupControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); 
    }
    
    void CreatePlayer()
    {
        Debug.Log("creating Player");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs","PhotonPlayer"), Vector3.zero,Quaternion.identity);
    }
}
