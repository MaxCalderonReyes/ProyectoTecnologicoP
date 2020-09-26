using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuletaMusic : MonoBehaviour
{
    public GameObject ruletaComienzo;
    public GameObject ruletaFinal;
    public GameObject ruletaFondo;
    public GameObject ruletawin;
    public GameObject ruletaganar;
    public GameObject ruletaperder;
    public static RuletaMusic instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ruletaganar.SetActive(false);
        ruletaperder.SetActive(false);
        ruletawin.SetActive(false);
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


    public void win()
    {
        ruletawin.SetActive(true);
        ruletaFondo.SetActive(false);
        ruletaComienzo.SetActive(false);
        ruletaFinal.SetActive(false);
    }

    public void ganar()
    {
        ruletaganar.SetActive(true);
    }
    public void  perder()
    {
        ruletaperder.SetActive(true);
    }

    public void desactivar()
    {
        ruletaganar.SetActive(false);
        ruletaperder.SetActive(false);
    }

    void Update()
    {
        
    }
}
