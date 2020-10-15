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
    [HideInInspector]public string Path;
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
        Path = Application.dataPath + "Datos.json";
        musicaOver.SetActive(false);
        playerSpri = GameObject.FindGameObjectWithTag("Player");


       
        Panel.SetActive(false);
        rgbd = GetComponent<Rigidbody2D>();
        BaseDatosNivel bd = new BaseDatosNivel(SceneManager.GetActiveScene().buildIndex);
        string content = JsonUtility.ToJson(bd, true);
        File.WriteAllText(Path, content);

    }

    // Update is called once per frame
    void Update()
    {
       
            InGround = (Physics2D.Raycast(transform.position, Vector2.down, DistanceTOGround, ground) || Physics2D.Raycast((Vector2)transform.position + Vector2.left * width / 2, Vector2.down, DistanceTOGround, ground)
                       || Physics2D.Raycast((Vector2)transform.position + Vector2.right * width / 2, Vector2.down, DistanceTOGround, ground));


            float x = Input.GetAxis("Horizontal");
            if (ActionsCan)
            {
                rgbd.velocity = new Vector3(x * speed, rgbd.velocity.y, 0);
                if (x < 0)
                {
                    playerSpri.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    playerSpri.GetComponent<SpriteRenderer>().flipX = false;
                }
                if (InGround)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SFXController.intance.OnJump();
                        rgbd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    }
                }
                shoot();
                Mousepos();
            }

        
       



        if (live <= 0)
        {
            vida();
            SFXController.intance.OnHurt();
           
            musica.SetActive(false);
            musicaOver.SetActive(true);   
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * DistanceTOGround);
    }
    public void shoot()
    {
        if (Input.GetMouseButtonDown(0)&&Shoot)
        {
            SFXController.intance.OnShoot();
         GameObject prfb=   Instantiate(prefab,transform.position,transform.rotation);
            if (!playerSpri.GetComponent<SpriteRenderer>().flipX)
            {
                prfb.GetComponent<BullDirections>().Direction(Mousepos());
            }
            else
            {
                prfb.GetComponent<BullDirections>().Direction(Mousepos());
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
            live -= 10;
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tumi"))
        {
            other.gameObject.GetComponent<Tumi>().MostrarBtn = false;
        }
    }
    IEnumerator canShoot()
    {
        Shoot = false;
        yield return new WaitForSecondsRealtime(SecondsToShoot);
        Shoot = true;
    }
}
