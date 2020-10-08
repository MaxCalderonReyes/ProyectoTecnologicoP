using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public static BOSS instancia;
    public List<Vector3> BullDirection;
   [SerializeField] private GameObject bala;
    private bool CinematicOFF=false;
    //Boss Campos Requeridos para hacer una accion
    [SerializeField]private int Charge;
    private bool canShot;
    [SerializeField]private bool defensa;
    public bool _DEFENSAS { get { return defensa; } }
   
    private float SecuenciaHabilidades;
    bool startcountAtack;
    private void Awake()
    {
        if (instancia == null) instancia = this;
    }
    void Start()
    {
        defensa = false;
      
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {

      
            SecuenciaHabilidades += Time.deltaTime;

       
        if (SecuenciaHabilidades <= 8)
        {
            ATAQUE();
            print("RealizandoATAQUE");
        }
        else
        {
            DEFENSA();
            print("RealizandoDefensa");
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
         
                for (int i = 0; i < BullDirection.Count; i++)
                {
                    GameObject bulls = Instantiate(bala, transform.position, transform.rotation);

                    bulls.GetComponent<BullDirections>().velocityShoot(6);
                    bulls.GetComponent<BullDirections>().Direction(BullDirection[i]);

                }

                StartCoroutine(CanShoot());
            
        
           
        }
       
     
    }public void HABILIDADESPECIAL()
    {
        //aca no se que hacer , la habilidad especial
    }
    IEnumerator CanShoot()
    {
        canShot = false;
        yield return new WaitForSeconds(Charge);
        canShot = true;
    }
    IEnumerator DesactivarEscudos()
    {
        yield return new WaitForSeconds(6);
        defensa = false;
        SecuenciaHabilidades = 0;
    }

}
