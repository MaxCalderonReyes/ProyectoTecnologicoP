using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rute : MonoBehaviour
{
    [SerializeField] private List<Vector3> positions;
    private int Pactual=0;
    [SerializeField]private float SmoothVelocity;
    [SerializeField]private IntroGame IGame;
    [SerializeField] private Animator presentacion;
    private bool AnimacionBossFInal=false; float countFinal = 0; float countStart = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (AnimacionBossFInal)
        {
        
            countFinal += Time.deltaTime;
        }
       
        countStart += Time.deltaTime;
     
        Vector3 DIreccion = positions[Pactual] - transform.position;
        if (countStart > 3)
        {
            transform.position += DIreccion * SmoothVelocity * Time.deltaTime;
            countStart = 5;
        }
       
        float Distancia = Vector2.Distance(transform.position, positions[Pactual]);
        if (Distancia < 6&&Pactual !=positions.Count-1)
        {
            Pactual += 1;
        }
        if (Pactual == positions.Count-1 && Distancia<1)
        {
            AnimacionBossFInal = true;
            presentacion.SetBool("GeneralAtoc", true);
            if (countFinal>5)
            {
                IGame._IntroGame = false;
            }
           
        }
      
      
       
    }
}
