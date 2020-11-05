using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bross : MonoBehaviour
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
    //Vida del enemigo
    public static Bross enmi;
    [SerializeField]private Slider slider;
    [SerializeField] private int live;
    public int Live
    {
        get { return live; }
        set { live = value; }
    }
    private void Awake()
    {
        if (enmi == null) enmi = this;
    }
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
        slider.value = live;
        SoldierEF();
        counter += Time.deltaTime * speed;

        if (horizontal)
        {
            


            actualPosition = transform.position.x;
            if (actualPosition < lastPosition)
            {
                sprite.flipX = false;
          
            }

            if (actualPosition > lastPosition)
            {
                sprite.flipX = true;
              
            }
          
           
            lastPosition = transform.position.x;
        }
        else


        {
           
        }






        if (live <= 0)
        {
            Destroy(gameObject);
        }
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
                    bull.GetComponent<BullDirections>().Direction(Vector3.right);
                }
                else
                {
                    bull.GetComponent<BullDirections>().Direction(Vector3.left);
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBull")
        {
            live -= 1;
        }
    }
}
