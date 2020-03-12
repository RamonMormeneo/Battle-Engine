using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using System.IO;

public class PlayerCon2 : MonoBehaviour
{
    private PhotonView PV;
    private bool find = false;
    public GameObject myAvatar;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int SpawnPicker = Random.Range(0, GameControler.GS.spawnpoint.Length);


        if (PV.IsMine)
        {
            for (int i = 0; i >= 4; i++)
            {
                if (GameControler.GS.spawnpoint[SpawnPicker] == GameControler.GS.pickeppoints[i])
                {
                    NewRand();
                }
            }

            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BaseLigera(Online)"), GameControler.GS.spawnpoint[SpawnPicker].transform.position, GameControler.GS.spawnpoint[SpawnPicker].transform.rotation, 0);

            myAvatar.transform.GetComponent<HealtOnline>().inictrans = GameControler.GS.spawnpoint[SpawnPicker].transform;
            GameControler.GS.pickeppoints[SpawnPicker] = GameControler.GS.spawnpoint[SpawnPicker];

        }
        else
        {
            Destroy(gameObject);
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
