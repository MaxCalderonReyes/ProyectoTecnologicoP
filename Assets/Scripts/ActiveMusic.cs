using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMusic : MonoBehaviour
{
    public GameObject musica;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void activate()
    {
        musica.SetActive(true);
    }

    public void desactivate()
    {
        musica.SetActive(false);
    }

}
