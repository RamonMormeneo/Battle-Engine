using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    bool follow_player = false;
    GameObject actualPlayer;
    float timer = 16.0f;

    void LateUpdate()
    {
        if (follow_player && actualPlayer != null) 
        {
            timer -= Time.deltaTime;
            gameObject.GetComponent<Rigidbody>().constraints =
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
            //Follow Ball
            transform.position = actualPlayer.transform.position;
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), actualPlayer.GetComponent<Collider>());
            if (timer <= 0)
            {
                gameObject.GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.None;
                follow_player = false;
                timer = 16.0f;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ball_Player")
        {
            follow_player = true;
            actualPlayer = col.gameObject;
        }
    }
}
