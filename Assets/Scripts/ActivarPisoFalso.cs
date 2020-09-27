using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPisoFalso : MonoBehaviour
{
    private float timer;
    private bool activarTrampa;
    [SerializeField] private GameObject suelo;
    private BoxCollider2D boxCollider2D;

    public bool ActivarTrampa { get => activarTrampa; set => activarTrampa = value; }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        timer = 0;
        activarTrampa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activarTrampa)
        {
            timer += Time.deltaTime;
            if (timer >= 2 && suelo.activeSelf == true)
            {
                suelo.SetActive(false);
                boxCollider2D.enabled = false;
                timer = 0;
            }
            if (timer >= 3 && suelo.activeSelf == false)
            {
                suelo.SetActive(true);
                boxCollider2D.enabled = true;
                timer = 0;
                activarTrampa = false;
            }
        }
    }
}
