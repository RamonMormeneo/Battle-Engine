﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public static GameControler GS;
    public Transform[] spawnpoint;
    private void OnEnable()
    {
        if(GameControler.GS ==null)
        {
            GameControler.GS = this;
        }
    }
}
