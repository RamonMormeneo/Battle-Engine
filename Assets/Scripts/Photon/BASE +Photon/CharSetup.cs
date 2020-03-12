using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class CharSetup : MonoBehaviourPunCallbacks
{
    private PhotonView PV;

    public Camera MyCamera;
    public AudioListener MyAL;
    private HealtOnline health;
    public bool Ready=false;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        health= GetComponent<HealtOnline>();
        if (PV.IsMine)
        {
            //PV.RPC("RPC_AddCharacter")
            MyCamera.gameObject.SetActive(true);
            
            health.currentHealth = 100;
            health.Healthbar.sizeDelta = new Vector2(health.currentHealth * 2, health.Healthbar.sizeDelta.y);
            if(PhotonNetwork.CurrentRoom.PlayerCount==PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                Ready = true;
            }
        }
        else
        {
          
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        SceneManager.LoadScene(4);
    }
    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            Ready = true;
        }
        if ( PhotonNetwork.CurrentRoom.PlayerCount ==1 && Ready)
        {
            PhotonNetwork.LeaveRoom();
            while (PhotonNetwork.InRoom)
            {

            }
            SceneManager.LoadScene(3);
        }
    }
}
