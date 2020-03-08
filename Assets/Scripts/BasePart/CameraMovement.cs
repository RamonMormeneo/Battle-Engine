﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;

    public float turnSpeed = 4.0f;
    private Vector3 offset;

    //public GameObject torreta;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(4.0f, 19.0f, 35.0f);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {      
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = Player.transform.position + offset;
        transform.LookAt(Player.transform.position);

        //torreta.transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

    }

   

}
