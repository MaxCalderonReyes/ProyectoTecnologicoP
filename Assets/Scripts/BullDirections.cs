using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullDirections : MonoBehaviour
{
   
    private float speedbull;
    Vector3 _directionBull;
    [SerializeField] private bool Enemi;
 
    void Start()
    {
     
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    public void Direction(Vector3 directionbull)
    {
        _directionBull = directionbull;
    
    }
    public void velocityShoot(float bullvelocity)
    {
        speedbull = bullvelocity;
    }
    public void Update()
    {
        Vector3 Direction =  _directionBull;
       
        Vector3 Velocidad = Direction.normalized * speedbull;
        Vector3 Position = Velocidad * Time.deltaTime;
        transform.position += new Vector3(Position.x,Position.y,0);
   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.gameObject.tag == "Player"&&Enemi)
        {
        
            PlayerMovement.instancie.live -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy"&&!Enemi)
        {
            Destroy(gameObject);
        }
      
        
      
    }
}
