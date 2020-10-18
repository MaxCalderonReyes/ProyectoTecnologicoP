using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsOrder : MonoBehaviour
{
    public List<GameObject> puertas;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (TopDownMovement.instancia.Dts.level < 3)
        {
            puertas[0].SetActive(true);
            puertas[1].SetActive(false);
            puertas[2].SetActive(false);
        }else if(TopDownMovement.instancia.Dts.level == 3)
        {
            puertas[0].SetActive(false);
            puertas[1].SetActive(true);
            puertas[2].SetActive(false);
        }
        else if (TopDownMovement.instancia.Dts.level == 6)
        {
            puertas[0].SetActive(false);
            puertas[1].SetActive(false);
            puertas[2].SetActive(true);
        }
    }
}
