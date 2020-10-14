using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBossLevel3 : MonoBehaviour
{
    public static SpecialBossLevel3 instnacie;
    public Animator animator;
    [SerializeField] private Animator textPresentation;
    private void Awake()
    {
        if (instnacie == null)
        {
            instnacie = this;
        }
    }
    void Start()
    {
       
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
   public void StartPresentation()
    {
        textPresentation.SetBool("Presentation",true);
    }
}
