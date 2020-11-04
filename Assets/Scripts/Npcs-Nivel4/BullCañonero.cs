using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullCañonero : MonoBehaviour
{
    [SerializeField]private float velocidadBala;
    [SerializeField]private float limite;
    [SerializeField]private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * velocidadBala);
        if (transform.position.y <= limite)
        {
            Destroy(gameObject);
        }
    }
}
