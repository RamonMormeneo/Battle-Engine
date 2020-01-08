using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Shooting : NetworkBehaviour
{
    public GameObject Bullet_Prefab;
    public Transform Bullet_Spawn;
 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }
    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(Bullet_Prefab, Bullet_Spawn.position,Bullet_Spawn.rotation);

        // add velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100.0f;

        //Spawn teh bullet on the clients
        NetworkServer.Spawn(bullet);
        //Destroy (2s)
        Destroy(bullet, 2);
        
    }
}
