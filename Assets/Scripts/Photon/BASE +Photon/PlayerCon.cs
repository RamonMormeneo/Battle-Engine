﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using System.IO;

public class PlayerCon : MonoBehaviour
{
    private PhotonView PV;
    private bool find = false;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int SpawnPicker = Random.Range(0, GameControler.GS.spawnpoint.Length);
       
       
        if (PV.IsMine)
        {
            for(int i =0;i >= 4; i++)
            {
                if(GameControler.GS.spawnpoint[SpawnPicker] == GameControler.GS.pickeppoints[i])
                {
                    NewRand();
                }
            }
           
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BASE2"), GameControler.GS.spawnpoint[SpawnPicker].transform.position, GameControler.GS.spawnpoint[SpawnPicker].transform.rotation, 0);
            GameControler.GS.pickeppoints[SpawnPicker] = GameControler.GS.spawnpoint[SpawnPicker];
        }
    }
    void NewRand()
    {
        int SpawnPicker = Random.Range(0, GameControler.GS.spawnpoint.Length);
        for (int i = 0; i >= 4; i++)
        {
            if (GameControler.GS.spawnpoint[SpawnPicker] == GameControler.GS.pickeppoints[i])
            {
                NewRand();
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}