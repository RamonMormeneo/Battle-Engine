using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class Shooting : /*NetworkBehaviour*/ MonoBehaviour
{
    public GameObject Bullet_Prefab;
    public GameObject Bullet_Gancho;
    public GameObject Cadenas;
    public GameObject Bola_PEM;   
    public GameObject Bullet_Alquitran;
    public Transform Bullet_Spawn;
    public GameObject Torreta;
    private PhotonView PV;
    //Camera: 
    public GameObject cam;

    //El gancho y el disparo basico tendrian que tenerse siempre como habilidades comunes. 
    //Las demas adicionales? 
    public enum Abilites { Lanzallas, PEM, Alquitran, Sierras, Gancho }

    //Objects: 
    public GameObject [] Sierras;

    //Particles: 
    public GameObject prefabLanzallamas; public Transform emitterPos; public GameObject AreaLlamas;

    //CD: 
    private float CDLanzallamas = 4.0f;
    private float CDGancho = 10.0f;

    //Abilites
    public Abilites abilities;
    private bool GOINGCD = false;
    private bool GOINGCDGANCHO = false;

    private Rigidbody body;

    public AudioSource turretShot;
    public AudioSource flameSound;
    public AudioSource sawSound;
    public AudioSource whistle;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        //if (!isLocalPlayer)
        //{
        //    return;
        //}
        if (PV.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Switch: Abilities.
                CmdFire();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(transform.forward * -60000.0f, ForceMode.Impulse);
                whistle.Play();
            }


            //Torreta gira con la camara: //Try: not working.
            Torreta.transform.localEulerAngles =
                new Vector3(Torreta.transform.localEulerAngles.x,
                cam.transform.localEulerAngles.y,
                Torreta.transform.localEulerAngles.z);


            // Entrada a escoger de habilidad.
            switch (abilities)
            {
                case Abilites.Lanzallas:
                    //Code to shoot here:
                    if (Input.GetKeyDown(KeyCode.Space) && CDLanzallamas == 4.0f && GOINGCD == false)
                    {
                        CmdLanzallamas();
                        print("SHOOT");
                        GOINGCD = true;
                    }
                    if (GOINGCD)
                    {
                        CDLanzallamas -= Time.deltaTime;
                        if (CDLanzallamas <= 0.0f)
                        {
                            flameSound.Play();
                            CDLanzallamas = 4.0f;
                            AreaLlamas.GetComponent<Collider>().enabled = false;
                            GOINGCD = false;
                        }
                    }
                    break;
                case Abilites.Alquitran:
                    break;
                case Abilites.PEM:
                    break;
                case Abilites.Sierras:
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        sawSound.Play();
                        CmdSierras();
                    }
                    else
                    {
                        sawSound.Pause();
                    }
                    break;
                case Abilites.Gancho:
                    //if (Input.GetMouseButtonDown(0) && GOINGCDGANCHO == false) //Boton izquierdo disparamos gancho.
                    //{
                    //    CmdGancho();
                    //    CDGancho = 10.0f;
                    //    GOINGCDGANCHO = true;
                    //}
                    //if(GOINGCDGANCHO)
                    //{
                    //    CDGancho -= Time.deltaTime;
                    //    if(CDGancho <= 0.0f)
                    //    {                       
                    //        GOINGCDGANCHO = false;
                    //    }            
                    //}
                    break;
            }
        }


    }
    //[Command]
    void CmdFire()
    {
        GameObject bullet = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bullet(Online)"), Bullet_Spawn.position, Bullet_Spawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * 250.0f, ForceMode.Impulse);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * 100.0f, ForceMode.Impulse);

        turretShot.Play();

        // add velocity
        //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100.0f;

        //Spawn teh bullet on the clients
        //NetworkServer.Spawn(bullet);
        //Destroy (2s)
        //Destroy(bullet, 2);

    }

    //[Command]
    void CmdGancho()
    {
        GameObject cadenas = (GameObject)Instantiate(Cadenas, Bullet_Spawn.position, Cadenas.transform.rotation); // Cadenas
        //cadenas.transform.parent = gameObject.transform;
        GameObject bullet = (GameObject)Instantiate(Bullet_Gancho, Bullet_Spawn.position, Bullet_Spawn.rotation); // Bola

        bullet.GetComponent<IK_FABRIK2>().target = bullet.gameObject.transform;
        bullet.GetComponent<IK_FABRIK2>().joints = new Transform[4]; //Carefully here, hardcode. 

        bullet.GetComponent<IK_FABRIK2>().joints[0] = cadenas.gameObject.transform;
        bullet.GetComponent<IK_FABRIK2>().joints[1] = cadenas.gameObject.transform.GetChild(1).transform;
        bullet.GetComponent<IK_FABRIK2>().joints[2] = cadenas.gameObject.transform.GetChild(1).transform.GetChild(1).transform;
        bullet.GetComponent<IK_FABRIK2>().joints[3] = cadenas.gameObject.transform.GetChild(1).transform.GetChild(1).transform.
            GetChild(1).transform;

        bullet.GetComponent<IK_FABRIK2>().maxIterations = 10;
        bullet.GetComponent<IK_FABRIK2>().base_ = gameObject;

        // add velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100.0f;

        Destroy(bullet, 10.0f);
        Destroy(cadenas, 10.0f);

        //Spawn teh bullet on the clients
        //NetworkServer.Spawn(cadenas);
        //NetworkServer.Spawn(bullet);
        //Destroy (2s)
        //Destroy(bullet, 2);

    }

    void CmdPEM(float F)
    {
        GameObject obj = Instantiate(Bola_PEM, Bullet_Spawn.position, Bola_PEM.transform.rotation); // Instanciar tiro.
        obj.GetComponent<Rigidbody>().AddForce(-transform.forward * F, ForceMode.Impulse);
    }

    void CmdAlquitran(float F)
    {
        GameObject obj = Instantiate(Bullet_Alquitran, Bullet_Spawn.position, Bullet_Alquitran.transform.rotation); // Instanciar tiro.
        obj.GetComponent<Rigidbody>().AddForce(-transform.forward * F, ForceMode.Impulse);
    }

    void CmdLanzallamas()
    {
        //1. Instanciamos particulas. 
        GameObject flame = Instantiate(prefabLanzallamas, emitterPos.position, Quaternion.identity * new Quaternion(0.0f, 90.0f, 0.0f, 1.0f));
        Destroy(flame, 4.0f);
        //2. Activate Trigger.
        AreaLlamas.GetComponent<Collider>().enabled = true;
        AreaLlamas.GetComponent<Collider>().isTrigger = true;
    }

    void CmdSierras()
    {
        for (int i = 0; i < Sierras.Length; i++)
        {
            Sierras[i].gameObject.GetComponent<Sierras>().Activated =
                !Sierras[i].gameObject.GetComponent<Sierras>().Activated;
        }
    }

}
