using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBossLevel3 : MonoBehaviour
{
    public static SpecialBossLevel3 instnacie;
    public Animator animator;
     public Animator textPresentation;
    private bool Carrera;
    private float count;
    public List<GameObject> bulls;
    int tiempoDisparo;
    [SerializeField]private StaticParalax staticParalax;
    [SerializeField]private IntroGame intro;
    
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
        
        for (int i = 0; i < bulls.Count; i++)
        {
           
            GameObject bul = Instantiate(bulls[i],transform.position , transform.rotation);
            bul.GetComponent<BullDirections>().Direction(Vector2.down);
            bul.GetComponent<BullDirections>().velocityShoot(5);

        }
        
    }
   private void Update()
    {
        if (Carrera)
        {
            count += Time.deltaTime;
            while (count < 40)
            {
                Run();
                StartCoroutine(DispararCada());
            }

            if (count > 40)
            {
                Carrera = false;
                intro._JustLook = false;
            }
        }
     
      
     
    }
    IEnumerator DispararCada()
    {
        yield return new WaitForSeconds(tiempoDisparo);
    }
    public void StartRun()
    {
        Carrera = true;
    }
    public void MovementRestrictions()
    {
        intro._JustLook = true;
        PlayerMovement.instancie.transform.position = new Vector3(Mathf.Clamp(transform.position.x, 366, 393), transform.position.y, 0);
        
    }
}
