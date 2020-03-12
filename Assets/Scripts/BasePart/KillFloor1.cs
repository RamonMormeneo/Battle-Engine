using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        GameObject hit = collision.gameObject;
        HealtOnline health = hit.GetComponent<HealtOnline>();

        if (health != null)
        {
            health.TeakeDamge(dmg);
        }
    }
}
