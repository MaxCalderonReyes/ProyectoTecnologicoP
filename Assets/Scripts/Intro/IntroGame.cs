using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroGame : MonoBehaviour
{
    private CinemachineVirtualCamera brain;
    [SerializeField]private GameObject FollowIntro;
    private bool InIntro=true;
    public bool _IntroGame
    {
        get { return InIntro; }
        set { InIntro = value; }
    }
    void Start()
    {
        brain = GetComponent<CinemachineVirtualCamera>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (InIntro)
        {
            brain.Follow = FollowIntro.transform;
            PlayerMovement.instancie._ActionCan = false;
        }
        else
        {
            brain.Follow = PlayerMovement.instancie.transform;
            PlayerMovement.instancie._ActionCan = true;
        }
    }
}
