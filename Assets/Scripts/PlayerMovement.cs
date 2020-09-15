using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    [SerializeField]private float speed;
    [SerializeField] private float JumpForce;
    [SerializeField]private LayerMask Ground;
    [SerializeField]private float DistanceGround;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D InGround = Physics2D.Raycast(transform.position,Vector2.down,DistanceGround,Ground);

        float x = Input.GetAxis("Horizontal");
 
        rgbd.velocity = new Vector2(x * speed,rgbd.velocity.y);
        if (InGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Salta");
                rgbd.AddForce(Vector2.up*JumpForce,ForceMode2D.Impulse);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
     
        Gizmos.DrawLine(transform.position,(Vector2)transform.position+ Vector2.down*DistanceGround);
    }
}
