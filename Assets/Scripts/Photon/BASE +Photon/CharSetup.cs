using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharSetup : MonoBehaviour
{
    private PhotonView PV;

    public Camera MyCamera;
    public AudioListener MyAL;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if(PV.IsMine)
        {
            //PV.RPC("RPC_AddCharacter")
            MyCamera.gameObject.SetActive(true);
        }
        else
        {
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
