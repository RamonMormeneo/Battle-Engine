using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    public GameObject Cam;
    private PhotonView PV;
    public Vector3 move;
    public Vector3 velocity; 
    public float maxSpeed;  //No poner valores aqui, porque los del editor no se utilizaran. 
    public float mSpeed;
    public float acceleration = 5.0f; 
    public float brake = 5.0f; 
    public float turnSpeed = 45.0f;
    public float speed = 0.0f;
    private Rigidbody body;
    public float speed_multiply;
    public bool can_move = false;
    public bool BASELIGERA, BASEMEDIANA, BASEGRANDE;

    public bool Girar_Ruedas = false;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        if (BASEMEDIANA)
            transform.eulerAngles = new Vector3(-90, 0.0f, 180);
    }


    void FixedUpdate()
    {
        //WaitforPlayers h = FindObjectOfType<WaitforPlayers>();

        //can_move = h.thing;

      
        if (PV.IsMine&& can_move)
        {
            float turn = Input.GetAxis("Horizontal");
                if (BASEMEDIANA)
                {
                    
                    transform.Rotate(0.0f, 0, turn * turnSpeed * Time.deltaTime);
                } 
                else
                {
                    transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
                }


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

            speed = Mathf.Clamp(speed, -mSpeed, mSpeed);
            //if (speed > maxSpeed)
            //{
            //    speed = maxSpeed;
            //}
            //else if (speed < -maxSpeed)
            //{
            //    speed = -maxSpeed;
            //}

            Vector3 velocity = new Vector3(0.0f, 0.0f, speed);
            //transform.Translate(velocity * Time.deltaTime, Space.Self); // Old movement

            if (BASELIGERA)
            {
                body.MovePosition(transform.position - transform.right * speed * Time.deltaTime * speed_multiply);
            }
                
            if(BASEMEDIANA)
            {
                body.MovePosition(transform.position - transform.right * speed * Time.deltaTime * speed_multiply);
            }

            if (BASEGRANDE)
            {
                body.MovePosition(transform.position + transform.forward * speed * Time.deltaTime * speed_multiply);
            }
               
        }   
    }
    private void OnCollisionEnter(Collision collision)

    {
        speed = 0;
    }


}
