﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsOrder : MonoBehaviour
{
    public List<GameObject> puertas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TopDownMovement.instancia.Dts.level < 5)
        {
            puertas[0].SetActive(true);
            puertas[1].SetActive(false);
            puertas[2].SetActive(false);
        }else if(TopDownMovement.instancia.Dts.level >4&& TopDownMovement.instancia.Dts.level<7)
        {
            puertas[0].SetActive(false);
            puertas[1].SetActive(true);
            puertas[2].SetActive(false);
        }
        else if (TopDownMovement.instancia.Dts.level >7&& TopDownMovement.instancia.Dts.level<11)
        {
            puertas[0].SetActive(false);
            puertas[1].SetActive(false);
            puertas[2].SetActive(true);
        }
    }
}
