using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class OnLooby : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public static OnLooby lobby;

    public GameObject BattleButton;
    public GameObject CancelButton;
    public GameObject Text;
    public int NumPlayers;

    private void Awake()
    {
        lobby = this;
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        BattleButton.SetActive(true);
    }
    public void OnBBClick()
    {
        PhotonNetwork.JoinRandomRoom();
        BattleButton.SetActive(false);
        CancelButton.SetActive(true);
        Text.SetActive(true);
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room available");
        createroom();

    }
    public void createroom()
    {
        int random = Random.Range(0, 1000000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("Room" + random, roomOps);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        createroom();
    }
    public void OnCBClick()
    {
        BattleButton.SetActive(true);
        CancelButton.SetActive(false);
        Text.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.InRoom)
        {
            Room myroom = PhotonNetwork.CurrentRoom;
            NumPlayers = myroom.PlayerCount;
        }
    }
}
