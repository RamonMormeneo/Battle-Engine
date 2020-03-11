using System.Collections;
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
       for(int i = GameControler.GS.pickeppoints.Length;i <= 0; i--)
        {
            if(SpawnPicker== GameControler.GS.pickeppoints[i])
            {
                NewRand(i);
            }
        }
        if (PV.IsMine)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BASE2"), GameControler.GS.spawnpoint[SpawnPicker].transform.position, GameControler.GS.spawnpoint[SpawnPicker].transform.rotation, 0);
        }
    }
    void NewRand(int i)
    {
        int SpawnPicker = Random.Range(0, GameControler.GS.spawnpoint.Length);
        if (SpawnPicker == GameControler.GS.pickeppoints[i])
        {
            NewRand(i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
