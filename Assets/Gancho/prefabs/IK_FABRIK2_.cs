using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IK_FABRIK2_ : MonoBehaviour
{
    public Transform[] joints;
    public Transform target;

    private Vector3[] copy;
    private float[] distances;
    private bool done;

    float threshold_distance = 0.1f;
    public int maxIterations = 10;

    public GameObject base_;


    bool pelota = false;

    void Start()
    {
        distances = new float[joints.Length - 1];
        copy = new Vector3[joints.Length];
    }

    void Update()
    {
        // Copy the joints positions to work with
        // and calculate all the distances
        //TODO1
        for (int i = 0; i < joints.Length; i++)
        {
            copy[i] = joints[i].position;
            if (i < joints.Length - 1)
            {
                distances[i] = (joints[i + 1].position - joints[i].position).magnitude;
            }
        }

        done = (Vector3.Distance(target.position, joints[joints.Length - 1].position) < threshold_distance);

        if (!done)
        {
            float targetRootDist = Vector3.Distance(copy[0], target.position);

            // Update joint positions
            if (targetRootDist > distances.Sum())
            {
                // The target is unreachable
                //TODO3
                for (int i = 0; i < copy.Length - 1; i++)
                {
                    float dist = (target.position - copy[i]).magnitude;
                    float ratio = distances[i] / dist;

                    copy[i + 1] = (1 - ratio) * copy[i] + ratio * target.position;

                }
            }
            else
            {
                int counter = 0;
                // The target is reachable
                while (!done && counter < maxIterations)
                {
                    counter++;

                    // STAGE 1: FORWARD REACHING
                    //TODO5
                    copy[copy.Length - 1] = target.position;
                    for (int i = copy.Length - 1; i > 0; i--)
                    {
                        Vector3 temp = (copy[i - 1] - copy[i]).normalized;
                        temp = temp * distances[i - 1];
                        copy[i - 1] = temp + copy[i];
                    }
                    // STAGE 2: BACKWARD REACHING
                    //TODO6
                    copy[0] = joints[0].position;
                    for (int i = 0; i < copy.Length - 2; i++)
                    {
                        Vector3 temp = (copy[i + 1] - copy[i]).normalized;
                        temp = temp * distances[i];
                        copy[i + 1] = temp + copy[i];
                    }
                    done = (Vector3.Distance(target.position, joints[joints.Length - 1].position) < threshold_distance);
                }
            }

            // Update original joint rotations
            for (int i = 0; i <= joints.Length - 2; i++)
            {
                //TODO 4.
                //with rotations:
                Vector3 a, b;
                a = joints[i + 1].position - joints[i].position;
                b = copy[i + 1] - copy[i];
                Vector3 axis = Vector3.Cross(a, b).normalized;

                float cosa = Vector3.Dot(a, b) / (a.magnitude * b.magnitude);
                float sina = Vector3.Cross(a.normalized, b.normalized).magnitude;

                float alpha = Mathf.Atan2(sina, cosa);
                Quaternion q = new Quaternion(axis.x * Mathf.Sin(alpha / 2), axis.y * Mathf.Sin(alpha / 2), axis.z * Mathf.Sin(alpha / 2), Mathf.Cos(alpha / 2));
                joints[i].position = copy[i];
                joints[i].rotation = q * joints[i].rotation;
            }
        }

        if (pelota)
        {
            //base_.GetComponent<Shooting>().Bullet_Spawn.position.y
            transform.position = new Vector3
                (joints[3].transform.position.x, transform.position.y, joints[3].transform.position.z);
            joints[0].transform.position =
                new Vector3(base_.transform.position.x, base_.GetComponent<Shooting>().Bullet_Spawn.position.y,   base_.transform.position.z);
            //Destruir cadena si no da a un enemigo. 
            //Destruir cadena una vez haya acabado el efecto en el enemigo ( Cuando se suelta ). 
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject.GetComponent<Rigidbody>());
        //pelota = true;
        if (collision.gameObject.tag == "Player")
        {
            ////Ignorar colision de la pelota con las cadenas. 
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>(), true);
            pelota = true;
        } 
        else
        {
            //Destroy(this.gameObject);
        }
    }

}
