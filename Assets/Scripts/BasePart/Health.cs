using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
   [SyncVar (hook = "onChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform Healthbar;
    private NetworkStartPosition[] spawnPoints;
    private int num;
    // Start is called before the first frame update

    private void Start()
    {
        if(isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition> ();
            Health[] temp= FindObjectsOfType<Health>();
            num = temp.Length;
            Debug.Log(num);
        }
    }
    public void TeakeDamge(int amount)
    {
       
        if(!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            RpcSpawnplayer();
        }
        
    }

    void onChangeHealth(int health)
    {
        Healthbar.sizeDelta = new Vector2(health * 2, Healthbar.sizeDelta.y);
    }
    [ClientRpc]
    void RpcSpawnplayer()
    {
        if(isLocalPlayer)
        {
            Vector3 SpawnPoint = Vector3.zero;
            
            transform.position = spawnPoints[num-1].transform.position;
        }
        currentHealth = maxHealth;
    }
}
