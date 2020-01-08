using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWheels : MonoBehaviour
{
    public GameObject base_;
    private float acc = 1;

    void Update()
    {
        if (base_.GetComponent<Movement>().Girar_Ruedas)
        {
            acc += 1.0f;
            this.gameObject.transform.Rotate(-Vector3.forward * acc * Time.deltaTime);
        }
        else if (!base_.GetComponent<Movement>().Girar_Ruedas && acc > 1)
        {
            acc -= 2.0f;
            this.gameObject.transform.Rotate(-Vector3.forward * acc * Time.deltaTime);
        }

    }
}