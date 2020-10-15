using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuve : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float speed;
    

    void Start()
    {
        
    }

   
    void Update()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity = new Vector2(speed, 0);

        
    }
}
