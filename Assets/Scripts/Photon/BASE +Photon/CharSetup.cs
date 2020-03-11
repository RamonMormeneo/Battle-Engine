using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharSetup : MonoBehaviour
{
    private PhotonView PV;

    public Camera MyCamera;
    public AudioListener MyAL;
    private HealtOnline health;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        health= GetComponent<HealtOnline>();
        if (PV.IsMine)
        {
            //PV.RPC("RPC_AddCharacter")
            MyCamera.gameObject.SetActive(true);
            health.inictrans = gameObject.transform;
            health.currentHealth = 100;
            health.Healthbar.sizeDelta = new Vector2(health.currentHealth * 2, health.Healthbar.sizeDelta.y);
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
