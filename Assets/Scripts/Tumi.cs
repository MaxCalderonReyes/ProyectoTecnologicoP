using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tumi : MonoBehaviour
{
    [SerializeField]private Button btn;
    [SerializeField]private GameObject panelHistoria;
    [SerializeField]private Text textHistoria;
    [SerializeField] private String historiaNota;

    private GameObject joystick;
    private GameObject buttonJump;
    private GameObject buttonShoot;
    private bool mostrarBtn;

    public bool MostrarBtn { get => mostrarBtn; set => mostrarBtn = value; }
    private void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("joystick");
        buttonJump = GameObject.FindGameObjectWithTag("buttonJump");
        buttonShoot = GameObject.FindGameObjectWithTag("buttonShoot");
    }
    // Start is called before the first frame update
    void Start()
    {
        mostrarBtn = false;
        btn.gameObject.SetActive(false);
        panelHistoria.SetActive(false);

        textHistoria.text = "";
    }

    // Update is called once per frame
    void Update()
    {        
        if (mostrarBtn)
        {
            btn.gameObject.SetActive(true);
        }
        else
        {
            btn.gameObject.SetActive(false);
        }
    }

    public void mostrarHistoria()
    {
        textHistoria.text = historiaNota;
        panelHistoria.SetActive(true);
        mostrarBtn = false;

        joystick.SetActive(false);
        buttonJump.SetActive(false);
        buttonShoot.SetActive(false);
    }

    public void ocultarHistoria()
    {
        panelHistoria.SetActive(false);
        textHistoria.text = "";

        joystick.SetActive(true);
        buttonJump.SetActive(true);
        buttonShoot.SetActive(true);
    }
}
