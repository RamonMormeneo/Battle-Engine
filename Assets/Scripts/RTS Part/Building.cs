using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{


    //////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////      Variables/referencias utiles para todo el script
    //////////////////////////////////////////////////////////////////


    bool constructionFinished = false;
    public Constructible constructible;
    public MyEvent onConstructionComplete;

    bool _canCraft = false;

    Renderer buildingRend;
    public Material originalMaterial;

    //////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////      Indicador para saber si podemos contruir o no en un sitio concreto
    //////////////////////////////////////////////////////////////////


    public bool canCraft
    {
        get
        {
            return _canCraft;
        }
        set
        {
            _canCraft = value;
            buildingRend.material.color = value ? Color.green : Color.red;
        }
    }

    //////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////      Lista de colliders, la usamos para ver si hay algun otro edificio o lo que sea encima de donde podemos contruir
    //////////////////////////////////////////////////////////////////


    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        if (colliders.Contains(other))
        {
            colliders.Remove(other);
        }
    }

    //////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////      Tiempo de crafteo, para que tarden un rato en contruirse los edificios
    //////////////////////////////////////////////////////////////////


    public int buildTime = 5;

    void CraftPoint()
    {
        buildTime--;
        if (buildTime <= 0)
        {
            constructionFinished = true;
            onConstructionComplete.Invoke();
            buildingRend.material.color = Color.blue;
            print("Craft Complete");
        }
    }


    void Start()
    {
        buildingRend = GetComponentInChildren<Renderer>();
    }
}
