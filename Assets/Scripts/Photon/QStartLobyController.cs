using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QStartLobyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject QStartButton; //Boton para crear y unirse a una partida
    [SerializeField]
    private GameObject QCancelButton; //Boton para cancelar la busqueda de partida
    [SerializeField]
    private int maxPlayer; // El numero max de jugadores en 1 habitación

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true; //
        QStartButton.SetActive(true);
    }
    
    public void QuickStart()
    {
        QStartButton.SetActive(false);
        QCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); // si ya existe una sala se une
        Debug.Log("Quick Start");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed To log");
        CreateRoom();
    }
    public void CreateRoom()
    {
        Debug.Log("Creating new Room");
        int randomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)maxPlayer};
        PhotonNetwork.CreateRoom("Room"+randomNumber,roomOps);
        Debug.Log(randomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Creat Room fail, try again");
        CreateRoom();
    }
    public void QuickCancel()
    {
        QStartButton.SetActive(true);
        QCancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
   
}
