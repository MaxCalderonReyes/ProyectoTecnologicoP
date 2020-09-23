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
        Panel.SetActive(false);
        rgbd = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D InGround = Physics2D.Raycast(transform.position,Vector2.down,DistanceTOGround,ground);
        float x = Input.GetAxis("Horizontal");
        
        rgbd.velocity = new Vector3(x * speed, rgbd.velocity.y, 0);
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
            prfb.GetComponent<BullDirections>().Direction(Mousepos());
            prfb.GetComponent<BullDirections>().velocityShoot(15);
        }
    }
    private Vector3 Mousepos()
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
