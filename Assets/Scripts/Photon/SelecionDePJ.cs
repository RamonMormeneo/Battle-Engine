using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;
public class SelecionDePJ : MonoBehaviourPunCallbacks
{
    public static SelecionDePJ SPJ;
    public enum Coches { Colosso, Hippo, Beetle }
    public Coches elcoche;
    public int CurrentScene;
    public int multiplayerScene;
    private void Awake()
    {
        if(SelecionDePJ.SPJ == null)
        {
            SelecionDePJ.SPJ = this;
        }
        else
        {
            if(SelecionDePJ.SPJ != this)
            {
                Destroy(SelecionDePJ.SPJ.gameObject);
                SelecionDePJ.SPJ = this;

            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void Colosso()
    {
        elcoche = Coches.Colosso;
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);
    }
    public void Hippo()
    {
        elcoche = Coches.Hippo;
        /*if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);*/
    }
    public void Beetle()
    {
        elcoche = Coches.Beetle;
       
    }
    
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishLoading;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishLoading;
    }
    public void GameStart()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);
    }
    void OnSceneFinishLoading(Scene scene, LoadSceneMode mode)
    {
        CurrentScene = scene.buildIndex;
        if (CurrentScene == multiplayerScene)
        {
            LoadPlayer();
        }

    }
   
    private void LoadPlayer()
    {
        switch (elcoche)
        {
            case Coches.Colosso:
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerStart"), transform.position, Quaternion.identity, 0);
                break;
            case Coches.Beetle:
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerStart2"), transform.position, Quaternion.identity, 0);
                break;
            case Coches.Hippo:
                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerStart3"), transform.position, Quaternion.identity, 0);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
