using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using System.IO;

public class PlayerCon : MonoBehaviour
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int SpawnPicker = Random.Range(0, GameControler.GS.spawnpoint.Length);
        if (PV.IsMine)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BASE1 (1)"), GameControler.GS.spawnpoint[0].position, GameControler.GS.spawnpoint[0].rotation, 0);
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerStart"), GameControler.GS.spawnpoint[0].position, Quaternion.identity, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
