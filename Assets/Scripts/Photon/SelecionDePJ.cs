using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;
public class SelecionDePJ : MonoBehaviour
{
    public static SelecionDePJ SPJ;
    public enum Coches { Colosso, Hippo, Beetle }
    Coches elcoche;
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
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);
    }
    public void Beetle()
    {
        elcoche = Coches.Beetle;
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);
    }
    public void OncharPick(int wichchar)
    {
        if(PlayerInf.PI!=null)
        {
            PlayerInf.PI.MYselectedChar = wichchar;
            PlayerPrefs.SetInt("MyCharacet", wichchar);
        }
    }
    public void LoadLv1()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
