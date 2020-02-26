using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    bool follow_player = false;
    GameObject actualPlayer;
    float timer = 16.0f;

    void Update()
    {
        if (follow_player) {

            timer -= Time.deltaTime;
            transform.position = actualPlayer.transform.position;
            if(timer <= 0)
            {
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
