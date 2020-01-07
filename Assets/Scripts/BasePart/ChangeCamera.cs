﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class ChangeCamera : NetworkBehaviour
{
    public GameObject Cam;
    public GameObject Cam2;
    // Start is called before the first frame update
    void Start()
    {
        Cam2.SetActive(false);
        if (isLocalPlayer)
        {
            Cam.SetActive(true);

        }
        else
        {
            Cam.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(Cam.activeSelf == true)
            {
                Cam2.SetActive(true);
                Cam.SetActive(false);
            }
            else
            {
                Cam2.SetActive(false);
                Cam.SetActive(true);
            }
                
        }

    }
}