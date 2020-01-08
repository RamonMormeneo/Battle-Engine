using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public int dmg;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TeakeDamge(dmg);
        }

    }
}
