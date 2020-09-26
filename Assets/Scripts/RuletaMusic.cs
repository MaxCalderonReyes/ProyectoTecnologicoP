using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuletaMusic : MonoBehaviour
{
    public GameObject ruletaComienzo;
    public GameObject ruletaFinal;
    public GameObject ruletaFondo;
    public static RuletaMusic instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    
        ruletaComienzo.SetActive(false);
        ruletaFinal.SetActive(false);
    }

  

    public void Inicio()
    {
        ruletaComienzo.SetActive(true);
        ruletaFinal.SetActive(false);
    }

    public void Final()
    {
        ruletaComienzo.SetActive(false);
        ruletaFinal.SetActive(true);
    }




    void Update()
    {
        
    }
}
