using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaD : MonoBehaviour
{
    public static PuertaD intance;
    public GameObject muro;



    void Start()
    {
        intance = this;
    }

   
    void Update()
    {
     
    }


    public void s()
    {
        Destroy(muro);
    }
}
