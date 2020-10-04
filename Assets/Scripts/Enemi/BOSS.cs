using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public List<Vector3> BullDirection;
   [SerializeField] private GameObject bala;
    private bool CinematicOFF=false;
    //Boss Campos Requeridos para hacer una accion
    [SerializeField]private int Charge;
    private bool canShot;
    private bool defensa;
   
    private float SecuenciaHabilidades;
    bool startcountAtack;
    void Start()
    {
        defensa = false;
      
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        print(SecuenciaHabilidades);
        print(startcountAtack);
        if(startcountAtack)
        SecuenciaHabilidades += Time.deltaTime;
        if (SecuenciaHabilidades < 8)
        {
            ATAQUE();
        }
    
       
    }
    public void DEFENSA()
    {
        defensa = true;
        StartCoroutine(DesactivarEscudos());
    }
    public void ATAQUE()
    {
      
        if (canShot)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < BullDirection.Count; i++)
                {
                    GameObject bulls = Instantiate(bala, transform.position, transform.rotation);

                    bulls.GetComponent<BullDirections>().velocityShoot(6);
                    bulls.GetComponent<BullDirections>().Direction(BullDirection[i]);

                }

                StartCoroutine(CanShoot());
            }
            DEFENSA();
           
        }
       
     
    }public void HABILIDADESPECIAL()
    {

    }
    IEnumerator CanShoot()
    {
        canShot = false;
        yield return new WaitForSeconds(Charge);
        canShot = true;
    }
    IEnumerator DesactivarEscudos()
    {
        yield return new WaitForSeconds(4);
        defensa = false;
        SecuenciaHabilidades = 0;
    }

}
