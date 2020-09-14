using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    [SerializeField]private float speed;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rgbd.velocity = new Vector3(x * speed, y * speed, 0);
    }
}
