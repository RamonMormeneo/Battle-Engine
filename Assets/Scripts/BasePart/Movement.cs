using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    public GameObject Cam;

    public Vector3 move;
    public Vector3 velocity; 
    public float maxSpeed = 35.0f; 
    public float acceleration = 5.0f; 
    public float brake = 5.0f; 
    public float turnSpeed = 45.0f;
    private float speed = 0.0f;
    private Rigidbody body;
    public float speed_multiply;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (!hasAuthority)
        {
            return;
        }
        if (Cam.activeSelf == true)
            {
                float turn = Input.GetAxis("Horizontal");
                transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);


                float forwards = Input.GetAxis("Vertical");

                if (forwards > 0)
                {
                    speed = speed + acceleration * Time.deltaTime;
                }

                else if (forwards < 0)
                {
                    speed = speed - acceleration * Time.deltaTime;
                }

                else
                {
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
                //transform.Translate(velocity * Time.deltaTime, Space.Self); // Old movement
                body.MovePosition(transform.position + transform.forward * speed * Time.deltaTime * speed_multiply); // New movement
        }
        
       
    }
    private void OnCollisionEnter(Collision collision)

    {
        speed = 0;
    }


}
