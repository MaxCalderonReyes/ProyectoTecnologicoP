using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañonero : MonoBehaviour
{
    private Animator anim;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private Transform cañon;
    private float timer;
    private bool startAttack;
    private PedroDeCandia pedroDeCandia;


    void Awake()
    {
        anim = GetComponent<Animator>();
        pedroDeCandia = GameObject.FindGameObjectWithTag("PedroDeCandia").GetComponent<PedroDeCandia>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 1.8f;
        startAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        startAttack = pedroDeCandia.ActivarAtaque;

        if (startAttack)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Shoot();
                anim.SetTrigger("disparar");
                timer = 1.8f;
            }
        }              
    }

    private void Shoot()
    {
        bulletPrefab.transform.position = cañon.position;
        Instantiate(bulletPrefab);
    }
}