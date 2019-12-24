using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructBuilding : MonoBehaviour
{


    [SerializeField]
    LayerMask engineFloorMask;

    [SerializeField]
    public Building craftingBuilding;

    RaycastHit rh;

    public static ConstructBuilding singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
            return;
        }
        singleton = this;
    }



    // Update is called once per frame
    void Update()
    {
        if (craftingBuilding == null)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rh))
        {
            if (rh.collider.CompareTag("EngineBase"))
            {
                craftingBuilding.transform.position = rh.point;
                craftingBuilding.canCraft = rh.normal == Vector3.up;
                if (craftingBuilding.colliders.Count > 1)
                {
                    craftingBuilding.canCraft = false;
                }
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (craftingBuilding.canCraft == true)
            {
                craftingBuilding = null;
            }
        }
    }
}
