using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOpcion : MonoBehaviour
{
    public GameObject boton;
    public static ActiveOpcion instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        boton.SetActive(false);

    }

    public void activate()
    {
        boton.SetActive(true);
    }

    public void desactivate()
    {
        boton.SetActive(false);
    }
}
