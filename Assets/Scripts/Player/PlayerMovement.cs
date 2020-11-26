using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instancie;
    private Rigidbody2D rgbd;
    [SerializeField]private float speed;
    [SerializeField]private float Live;
    [SerializeField]private LayerMask ground;
   [SerializeField] private float DistanceTOGround;
    [SerializeField]private float jumpForce;
    //Disparo Del Player
    [SerializeField]private GameObject prefab;
    public GameObject Panel;
    [SerializeField]private float SecondsToShoot;
    private bool Shoot=true;
    private bool ActionsCan=true;

    [SerializeField] private Joystick joystick;
    //Animation
   [HideInInspector] public Animator animacionController;
    public bool Level3;
    public bool _ActionCan
    {
        get { return ActionsCan; }
        set { ActionsCan = value; }
    }
    public bool _shoot
    {
        get
        {
            return Shoot;
        }
    }
    GameObject playerSpri;


    public GameObject musica;
    public GameObject musicaOver;
    private Collider2D collider;
    private float width;
    private bool InGround;
    //Para el guardado de dato
    
    public void Awake()
    {
        if (instancie == null) instancie = this;
        collider = GetComponent<Collider2D>();
        width = collider.bounds.size.x;
       
    }
    public float live
    {
        get { return Live; }
        set { Live = value; }
    }

    void vida()
    {

        Panel.SetActive(true);
        Time.timeScale = 0;
        
    }


    void Start()
    {
        Level3 = false;
        animacionController = GetComponent<Animator>();
        musicaOver.SetActive(false);
        playerSpri = GameObject.FindGameObjectWithTag("Player");


       
        Panel.SetActive(false);
        rgbd = GetComponent<Rigidbody2D>();
     

    }

    // Update is called once per frame
    void Update()
    {
        print(Level3);
            InGround = (Physics2D.Raycast(transform.position, Vector2.down, DistanceTOGround, ground) || Physics2D.Raycast((Vector2)transform.position + Vector2.left * width / 2, Vector2.down, DistanceTOGround, ground)
                       || Physics2D.Raycast((Vector2)transform.position + Vector2.right * width / 2, Vector2.down, DistanceTOGround, ground));
        //Flujo de animaciones dependiendo de la velocidad del palyer (se usa blend three)0
        if (!Level3)
        {
            Debug.Log("ejecutandoaca");
            animacionController.SetFloat("Walk", Mathf.Abs(rgbd.velocity.x / speed));
        }
        else
        {
            Debug.Log("Ejecutandoestomejor");
            animacionController.SetFloat("Walk",(rgbd.velocity.x*0)+1);
        }
       
        animacionController.SetFloat("Jump", rgbd.velocity.y / speed);
        animacionController.SetBool("OnGround",InGround);
        ////////////////////////
        float x = joystick.Horizontal;
            if (ActionsCan)
            {
                rgbd.velocity = new Vector3(x * speed, rgbd.velocity.y, 0);
        
                if (x < 0)
                {
                
                
                
                playerSpri.GetComponent<SpriteRenderer>().flipX = true;
                }
                else if(x>0)
                {
               
                 
                
               
                    playerSpri.GetComponent<SpriteRenderer>().flipX = false;
                }else if (x == 0)
            {
                
                
                
              
            }

                //if (Input.GetKeyDown(KeyCode.Space))
                //{
               // SFXController.intance.OnJump();
                //Jump();
                //}

              
              //  Mousepos();
            }

        if (live >= 20)
        {
            live = 20;
        }

        if (live <= 0)
        {
            vida();
          SFXController.intance.OnHurt();
           
            musica.SetActive(false);
            musicaOver.SetActive(true);   
        }
    }

    public void Jump()

    {
     
        if (InGround)
        {
            audio();
            rgbd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            StartCoroutine(audio());

        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * DistanceTOGround);
    }
    public void shoot()
    {
        if (Shoot)
        {
           
         GameObject prfb=   Instantiate(prefab,transform.position,transform.rotation);
            if (!playerSpri.GetComponent<SpriteRenderer>().flipX)
            {
                prfb.GetComponent<BullDirections>().Direction(Vector3.right);
            }
            else
            {
                prfb.GetComponent<BullDirections>().Direction(Vector3.left);
            }
          
            prfb.GetComponent<BullDirections>().velocityShoot(15);
            StartCoroutine(canShoot());
        }
    }
    private Vector3 Mousepos()//opcional
    {
        Vector3 actualPos = transform.position;
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 MDirection = mousepos - actualPos;
     
        return MDirection;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            live--;
        }

        if (other.CompareTag("Boleadora"))
        {
            live -= 2;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("LanzasTrampa"))
        {
            live -= 5;
        }

        if (other.CompareTag("PisoFalso"))
        {
            other.gameObject.GetComponent<ActivarPisoFalso>().ActivarTrampa = true;
        }

        if (other.CompareTag("Rocas"))
        {
            live = 0;
        }

        if (other.CompareTag("Tumi"))
        {
            other.gameObject.GetComponent<Tumi>().MostrarBtn = true;
        }

        if (other.CompareTag("Bumeran"))
        {
            live -= 1;
        }
        if (other.CompareTag("Vida"))
        {
            live += 1;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BOSS2"))
        {
            live -= 5;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tumi"))
        {
            other.gameObject.GetComponent<Tumi>().MostrarBtn = false;
        }

        if (other.CompareTag("PedroDeCandia"))
        {
            other.gameObject.GetComponent<PedroDeCandia>().ActivarAtaque = true;
        }
    }
    IEnumerator canShoot()
    {
        Shoot = false;
        SFXController.intance.OnShoot();
        yield return new WaitForSecondsRealtime(SecondsToShoot);
        SFXController.intance.OffShoot();
        Shoot = true;
    }
    IEnumerator audio()
    {
        SFXController.intance.OnJump();
     
        yield return new WaitForSecondsRealtime(1);
   
        SFXController.intance.OffJump();
    }

   

}
