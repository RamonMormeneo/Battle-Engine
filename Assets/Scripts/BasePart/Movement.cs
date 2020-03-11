﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Cam;

    public Vector3 move;
    public Vector3 velocity; 
    public float maxSpeed = 35.0f; 
    public float acceleration = 5.0f; 
    public float brake = 5.0f; 
    public float turnSpeed = 45.0f;
    public float speed = 0.0f;
    private Rigidbody body;
    public float speed_multiply;
    public bool can_move = false;

    public bool Girar_Ruedas = false;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        WaitforPlayers h = FindObjectOfType<WaitforPlayers>();

        can_move = h.thing;

       
        
      
          float turn = Input.GetAxis("Horizontal");
          transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);


          float forwards = -(Input.GetAxis("Vertical"));

          if (forwards > 0)
          {
            Girar_Ruedas = true;
            speed = speed + acceleration * Time.deltaTime;
          }

          else if (forwards < 0)
          {
             Girar_Ruedas = true;
             speed = speed - acceleration * Time.deltaTime;
          }

        else
        {
           Girar_Ruedas = false;
            if (speed > 0)
            {
               speed = speed - brake * Time.deltaTime;
            }
            else
            {
              speed = speed + brake * Time.deltaTime;
            }
        }

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        Vector3 velocity = new Vector3(0.0f, 0.0f, speed);
                
        body.MovePosition(transform.position + transform.forward * speed * Time.deltaTime * speed_multiply); // New movement

       

        if (Input.GetKeyDown(KeyCode.E))
        {
            body.AddForce(transform.forward * -1800.0f, ForceMode.Impulse);
        }


    }
    private void OnCollisionEnter(Collision collision)

    {
        speed = 0;
    }


}
