using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Slider slider;
   [SerializeField] private Enemy enemigo;

    /// <summary>
    bool idleActive = true;
    bool todefense = true;
    /// </summary>

    private Animator animBoss;
    private bool PingPong=false;
    public bool _PingPong
    {
        get { return PingPong; }
    }
    private void Awake()
    {
        if (instancia == null) instancia = this;
    }
    void Start()
    {
        defensa = false;
        animBoss = GetComponent<Animator>();
        canShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        print(idleActive);
        print(PingPong);
        slider.value = enemigo.Live;
            SecuenciaHabilidades += Time.deltaTime;
        float DiSTPLAYER = Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position);
        if (DiSTPLAYER < 15f)
        {
            idleActive = false;
            PingPong = true;
        }
        else
        {
            PingPong = false;
        }
       
        if (SecuenciaHabilidades <= 8)
        {
            if (!idleActive)
            {
                animBoss.SetInteger("MODE", 3);
            }
            else
            {
                animBoss.SetInteger("MODE", 0);
            }
        
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
            animBoss.SetInteger("MODE", 1);
            StartCoroutine(CanShoot());
            
        
           
        }
       
     
    }
    IEnumerator CanShoot()
    {
        canShot = false;
        yield return new WaitForSeconds(Charge);
        canShot = true;
    }
    IEnumerator DesactivarEscudos()
    {
        if (!idleActive)
        {
            animBoss.SetInteger("MODE", 2);
        }
        else
        {
            animBoss.SetInteger("MODE", 0);
        }
        
        PingPong = true;
        yield return new WaitForSeconds(6);
        defensa = false;
        SecuenciaHabilidades = 0;
    }

}
