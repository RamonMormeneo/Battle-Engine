using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Cam2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

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
