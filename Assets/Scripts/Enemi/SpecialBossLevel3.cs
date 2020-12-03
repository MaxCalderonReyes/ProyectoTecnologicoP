using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBossLevel3 : MonoBehaviour
{
    public static SpecialBossLevel3 instnacie;
    public Animator animator;
     public Animator textPresentation;
    bool Oneretirade=false;
    private bool Carrera;
    public bool _Carrera
    {
        get => Carrera;
    }
    private float count;
    public List<GameObject> bulls;
     int tiempoDisparo;
    [SerializeField]private StaticParalax staticParalax;
    [SerializeField]private IntroGame intro;
    bool CanCount=true;
    [SerializeField] private StaticParalax Bridge;
    bool tt = false;

    private void Awake()
    {
        if (instnacie == null)
        {
            instnacie = this;
        }
    }
    void Start()
    {
        tiempoDisparo = 2;
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
   public void StartPresentation()
    {
        textPresentation.SetBool("Presentation",true);
    }
    public void StartOfFight()
    {
        staticParalax._InPersecute = true;
     
    }
    public void DesactiveBoxC()
    {
      ActiveDesactive.instnacia._startLastBattle.SetActive(false);
        PlayerMovement.instancie._ActionCan = true;
        intro._IntroGame = true;
        
    }
    private void Run()
    {
        if (CanCount)
        {
            for (int i = 0; i < bulls.Count; i++)
            {
                float xran = Random.Range(354,380);
                Vector3 vtemp = new Vector3(xran,-42,0);
                GameObject bul = Instantiate(bulls[i], vtemp, transform.rotation);
                bul.GetComponent<BullDirections>().Direction(Vector2.down);
                bul.GetComponent<BullDirections>().velocityShoot(5);
               

            }
            StartCoroutine(DispararCada());
        }
     
        

    }
   private void Update()
    {
       
        if (tt)
        {
            PlayerMovement.instancie.transform.position = new Vector3(Mathf.Clamp(PlayerMovement.instancie.transform.position.x, 354, 600), PlayerMovement.instancie.transform.position.y, 0);
        }
        if (Carrera)
        {
          
            PlayerMovement.instancie.transform.position = new Vector3(Mathf.Clamp(PlayerMovement.instancie.transform.position.x, 354, 380), PlayerMovement.instancie.transform.position.y, 0);
            
            count += Time.deltaTime;
            if (count < 40)
            {
                animator.SetBool("RUN", true);
                PlayerMovement.instancie.Level3 = true;
                print("Se esta ejectando");
                 Run();
              

            }

         
            


            if (count > 40)
            {
                tt = true;
                PlayerMovement.instancie.Level3 = false;
                Carrera = false;
                intro._JustLook = false;
                Bridge._InPersecute = false;
                Oneretirade = true;
                animator.SetBool("Retirade", true);
            }
          
        }
     
      
     
    }
    IEnumerator DispararCada()
    {
        CanCount = false;
        yield return new WaitForSeconds(tiempoDisparo);
        CanCount = true;
    }
    public void StartRun()
    {
        Carrera = true;
    }
    public void MovementRestrictions()
    {
        intro._JustLook = true;
        print("me estoy ejecutando");
      
        
    }
}
