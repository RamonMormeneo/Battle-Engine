using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class ResourceManager : MonoBehaviour
{

    public MyIntEvent2 whenResourcesChanges;

    [SerializeField]
    public int _resources;
    public int Resources
    {
        get { return _resources; }
        set
        {
            _resources = value;
            whenResourcesChanges.Invoke(Resources);
        }
    }


    public static ResourceManager singleton;

    void Start()
    {
        whenResourcesChanges.Invoke(Resources);
        if (singleton != null)
        {
            Destroy(gameObject);
            return;
        }
        singleton = this;

    }
}
