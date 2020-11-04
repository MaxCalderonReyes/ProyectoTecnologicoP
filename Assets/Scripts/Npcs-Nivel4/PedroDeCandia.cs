using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedroDeCandia : MonoBehaviour
{
    private Animator anim;
    private bool activarAtaque;

    public bool ActivarAtaque { get => activarAtaque; set => activarAtaque = value; }
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        activarAtaque = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("orden", activarAtaque);
    }
}
