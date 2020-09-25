using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    [SerializeField]private float speed;
    [SerializeField]private float Live;
    [SerializeField]private LayerMask ground;
   [SerializeField] private float DistanceTOGround;
    [SerializeField]private float jumpForce;
    //Disparo Del Player
    [SerializeField]private GameObject prefab;
    public GameObject Panel;
<<<<<<< HEAD
    GameObject playerSpri;

=======
    public GameObject musica;
    public GameObject musicaOver;
>>>>>>> 79598e98b85feae75a4243bb32bb66df3fd38aa6
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
<<<<<<< HEAD
        playerSpri = GameObject.FindGameObjectWithTag("Player");

=======

       
>>>>>>> 79598e98b85feae75a4243bb32bb66df3fd38aa6
        Panel.SetActive(false);
        rgbd = GetComponent<Rigidbody2D>();       
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D InGround = Physics2D.Raycast(transform.position,Vector2.down,DistanceTOGround,ground);
        float x = Input.GetAxis("Horizontal");
        
        rgbd.velocity = new Vector3(x * speed, rgbd.velocity.y, 0);
        if (x < 0)
        {
           playerSpri.GetComponent<SpriteRenderer>().flipX=true;
        }
        else
        {
            playerSpri.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (InGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rgbd.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
            }
        }
        shoot();
        Mousepos();


        if (live == 0)
        {
            vida();
            musica.SetActive(false);
           
            for (int i = 0; i <= 1; i++)
            {

                musicaOver.SetActive(true);

            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * DistanceTOGround);
    }
    public void shoot()
    {
        if (Input.GetMouseButtonDown(0))
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
    }
}
