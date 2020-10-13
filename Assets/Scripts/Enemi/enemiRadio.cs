﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemiRadio : MonoBehaviour
{

    [SerializeField] private LayerMask ground;
    public float _damage;
    public float speedy;

    public float Radio;

    private GameObject player;
    private Vector3 inicioPosition;
    private SpriteRenderer _sprite;
   
    private Rigidbody2D _rgbd;
   
   
    private Vector2 _posLastFrame;

   
    // Start is called before the first frame update

    private void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        _rgbd.freezeRotation = true;

        _rgbd.gravityScale = 0;
     
        _sprite = GetComponent<SpriteRenderer>();
    }



    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        inicioPosition = transform.position;
       
    }

    // Update is called once per frame
    void Update()


    {


         Physics2D.Raycast((Vector2)transform.position + Vector2.right  / 2, Vector2.down, ground);

        Vector3 target = inicioPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        Vector3 dir = (target - transform.position).normalized;


        if (dist < Radio)

        
            target = player.transform.position;
            float fixedSeed = speedy * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSeed);
           
 
            flix();
        _posLastFrame = transform.position;
        
    }
    


    void flix() {


        if (transform.position.x > _posLastFrame.x)
        {
            _sprite.flipX = true;
        }
        else if (transform.position.x < _posLastFrame.x)
        {
            _sprite.flipX = false;
        }

    }








    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,Radio );
    }





}