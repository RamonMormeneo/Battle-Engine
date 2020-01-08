using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Shooting : NetworkBehaviour
{
    public GameObject Bullet_Prefab;
    public GameObject Bullet_Gancho;
    public GameObject Cadenas;
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
        if(Input.GetMouseButtonDown(0)) //Boton izquierdo disparamos gancho.
        {
            CmdGancho();
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

    [Command]
    void CmdGancho()
    {
        GameObject cadenas = (GameObject)Instantiate(Cadenas, Bullet_Spawn.position, Cadenas.transform.rotation); // Cadenas
        //cadenas.transform.parent = gameObject.transform;
        GameObject bullet = (GameObject)Instantiate(Bullet_Gancho, Bullet_Spawn.position, Bullet_Spawn.rotation); // Bola
        bullet.GetComponent<IK_FABRIK2>().target = bullet.gameObject.transform;
        bullet.GetComponent<IK_FABRIK2>().joints = new Transform[4];

        bullet.GetComponent<IK_FABRIK2>().joints[0] = cadenas.gameObject.transform;
        bullet.GetComponent<IK_FABRIK2>().joints[1] = cadenas.gameObject.transform.GetChild(1).transform;
        bullet.GetComponent<IK_FABRIK2>().joints[2] = cadenas.gameObject.transform.GetChild(1).transform.GetChild(1).transform;
        bullet.GetComponent<IK_FABRIK2>().joints[3] = cadenas.gameObject.transform.GetChild(1).transform.GetChild(1).transform.
            GetChild(1).transform;
        bullet.GetComponent<IK_FABRIK2>().maxIterations = 10;

        bullet.GetComponent<IK_FABRIK2>().base_ = gameObject;

        // add velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100.0f;

        //Spawn teh bullet on the clients
        NetworkServer.Spawn(cadenas);
        NetworkServer.Spawn(bullet);
        //Destroy (2s)
        //Destroy(bullet, 2);

    }
}
