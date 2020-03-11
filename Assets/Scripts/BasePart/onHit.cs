using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour
{
    public int dmg;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        GameObject hit = collision.gameObject;
        HealtOnline health = hit.GetComponent<HealtOnline>();

        if(health != null)
        {
            health.TeakeDamge(dmg);
        }

        Destroy(gameObject);
    }
}
