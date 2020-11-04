using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroGame : MonoBehaviour
{
    
    private CinemachineVirtualCamera brain;
    [SerializeField]private GameObject FollowIntro;
    private bool InIntro=false;
    private bool JustLook=false;
    [SerializeField]private bool Mcamera;
    public static IntroGame intance;

    public bool _IntroGame
    {
        get { return InIntro; }
        set { InIntro = value; }
    }
    public bool _JustLook
    {
        get => JustLook;
        set => JustLook = value;
    }
    void Start()
    {
        brain = GetComponent<CinemachineVirtualCamera>();
        intance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mcamera)
        {
            GoIntro();
        }
        else
        {
            GoFight();
        }
       
    }
    public void GoIntro()
    {
        if (InIntro)
        {
            brain.Follow = FollowIntro.transform;
            PlayerMovement.instancie._ActionCan = false;
           
        }
        if (!InIntro)
        {
            brain.Follow = PlayerMovement.instancie.transform;
            PlayerMovement.instancie._ActionCan = true;
            Omitir.instance.desactivar();
        }

    }
    public void GoFight()
    {
        if (JustLook)
        {
            brain.Follow = FollowIntro.transform;
           
        }
        else
        {
            brain.Follow = PlayerMovement.instancie.transform;
        }
    }

    public void omitir()
    {
        InIntro = false;
        JustLook = false;
    }
}
