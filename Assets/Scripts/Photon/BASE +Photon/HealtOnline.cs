using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class HealtOnline : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth;
    public RectTransform Healthbar;
    private int num;
    public float maxLife = 3.0f;
    private PhotonView PV;
    public Transform inictrans;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();

    }
    public void TeakeDamge(int amount)
    {
        if(PV.IsMine)
        {
            currentHealth -= amount;
            
            Healthbar.sizeDelta = new Vector2(currentHealth * 2, Healthbar.sizeDelta.y);
            if (currentHealth<=0)
            {
                currentHealth = 0;
                RpcSpawnplayer();
            }
        }
    }

    public void RpcSpawnplayer()
    {
        if (PV.IsMine)
        {
            currentHealth = 100;
            Healthbar.sizeDelta = new Vector2(currentHealth * 2, Healthbar.sizeDelta.y);

        }
    }
}
