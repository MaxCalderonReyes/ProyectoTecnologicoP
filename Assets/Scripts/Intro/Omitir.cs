using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omitir : MonoBehaviour
{
    public static Omitir instance;
    public GameObject Omitir_;
    public GameObject Omitir2;
    void Start()
    {
        instance = this;
        
    }

    
    void Update()
    {
        
    }

    public void omitir()
    {
        IntroGame.intance.omitir();
    }
    public void desactivar()
    {
       Omitir_.SetActive(false);
       Omitir2.SetActive(false);
    }

}
