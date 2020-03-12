using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using UnityEngine.SceneManagement;


public class OnRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static OnRoom room;
    private PhotonView PV;
    public bool IsGameLoaded;
    public int CurrentScene;
    public int multiplayerScene;
    Player[] pPhotonPlayers;

    private void Awake()
    {
        if(OnRoom.room==null)
        {
            OnRoom.room = this;
        }
        else
        {
            if(OnRoom.room!=this)
            {
                Destroy(OnRoom.room.gameObject);
                OnRoom.room = this;

            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishLoading;
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        StartGame();
    }
 
    void StartGame()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);
    }
    void OnSceneFinishLoading(Scene scene, LoadSceneMode mode)
    {
        CurrentScene = scene.buildIndex;
        if(CurrentScene== multiplayerScene)
        {
            LoadPlayer();
        }
    }
    private void LoadPlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerStart"), transform.position, Quaternion.identity, 0);
    }
    // Update is called once per frame
    void Update()
    {
      
    }

}
