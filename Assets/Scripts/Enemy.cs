﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float lenght;
    private float counter;
    private float startPosition;

    private float actualPosition;
    private float lastPosition;

    [SerializeField]private bool horizontal;
    //Agregado al soldado;
    [SerializeField]private bool Soldier;
    private GameObject Player;
    [SerializeField]private float DistancieEnemigo;
    private SpriteRenderer sprite;
    //Especificaciones de la bala
    [SerializeField] private GameObject Bull;
    [SerializeField] private float velocidadBull;
    private bool canshoot=true;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        if (horizontal) startPosition = transform.position.x;
        else startPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        SoldierEF();
        counter += Time.deltaTime * speed;

        if (horizontal)
        {
            transform.position = new Vector2(Mathf.PingPong(counter, lenght) + startPosition, transform.position.y);
            actualPosition = transform.position.x;
            if (actualPosition < lastPosition) transform.localScale = new Vector3(-1, 1, 1);
            if (actualPosition > lastPosition) transform.localScale = new Vector3(1, 1, 1);
            lastPosition = transform.position.x;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(counter, lenght) + startPosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void SoldierEF()
    {
        if (Soldier)
        {
            float DistPlayer = Vector3.Distance(transform.position,Player.transform.position);
            if (DistPlayer < DistancieEnemigo&&canshoot)
            {
                GameObject bull = Instantiate(Bull,transform.position,transform.rotation);
                if (sprite.flipX)
                {
                    bull.GetComponent<BullDirections>().Direction(Vector3.left);
                }
                else
                {
                    bull.GetComponent<BullDirections>().Direction(Vector3.right);
                }
               
                bull.GetComponent<BullDirections>().velocityShoot(velocidadBull);
                StartCoroutine(CanShoot());
            }
        }
    }
    IEnumerator CanShoot()
    {
        canshoot = false;
        yield return new WaitForSeconds(1);
        canshoot = true;
    }
}
