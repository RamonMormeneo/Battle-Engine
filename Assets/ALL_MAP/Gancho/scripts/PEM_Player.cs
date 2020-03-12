using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEM_Player : MonoBehaviour
{
    float timer = 2.0f;
    bool activePEM = false;
    public AudioSource PEMSound;

    private void Update()
    {
        if(activePEM)
        {
            gameObject.GetComponent<Movement>().can_move = false;
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                gameObject.GetComponent<Movement>().can_move = true;
                timer = 2.0f;
                activePEM = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PEM")
        {
            activePEM = true;
            PEMSound.Play();
        }
    }

}
