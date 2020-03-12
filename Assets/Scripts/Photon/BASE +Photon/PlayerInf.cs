using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInf : MonoBehaviour
{
    public static PlayerInf PI;
    public int MYselectedChar;
    public GameObject[] allChar;

    private void OnEnable()
    {
        if(PlayerInf.PI == null)
        {
            PlayerInf.PI = this;
        }
        else
        {
            if(PlayerInf.PI!=this)
            {
                Destroy(PlayerInf.PI.gameObject);
                PlayerInf.PI = this;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("MyCharacter"))
        {
            MYselectedChar = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            MYselectedChar = 0;
            PlayerPrefs.SetInt("MyCharacet", MYselectedChar);
        }
    }

   
}
