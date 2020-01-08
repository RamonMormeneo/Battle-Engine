using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WaitforPlayers : NetworkBehaviour
{
    // Start is called before the first frame update
    public float numPlayers;
    private Movement[] num;
    public bool thing = false;
    public bool gameon = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num = FindObjectsOfType<Movement>();
        Debug.Log(numPlayers);
        if (num.Length == numPlayers)
        {
            thing = true;
            gameon = true;
        }
    }
    private void Thing()
    {
    }
}
