using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Constructor : MonoBehaviour
{
    public Building[] builds;
    public GameObject Cam;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addCraftPoint", 1, 1);
    }


    // Update is called once per frame
    void Update()
    {

        if (Cam.activeSelf == true)
        {
            BuildsLayout.singleton.DestroyAllChildren();
            for (int i = 0; i < builds.Length; i++)
            {
                int u = i;
                BuildsLayout.singleton.AddChildren(
                    builds[i].constructible.preview,
                    builds[i].constructible.price.ToString(),
                    () =>
                    {
                    //    if (builds[u].constructible.price > ResourceManager.singleton.Resources)
                    //    {
                    //        return;
                    //    }
                        var go = Instantiate(builds[u]);
                        ConstructBuilding.singleton.craftingBuilding = go;

                    }
                    );
            }
        }
    }
}
