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
    public float live
    {
        get { return Live; }
        set { Live = value; }
    }
    void Start()
    {
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
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * DistanceTOGround);
    }
}
