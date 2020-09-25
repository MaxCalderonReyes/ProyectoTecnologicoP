using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelToggle : MonoBehaviour
{
    private Wheel wheel;

    [SerializeField]
    private Text textBtn;


    private void Awake()
    {
        wheel = GameObject.FindGameObjectWithTag("Wheel").GetComponent<Wheel>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textBtn.text = "GIRAR";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spin()
    {        
        if (wheel.Toggle == false)
        {
            textBtn.text = "PARAR";
            wheel.Toggle = true;
        }
        else
        {
            textBtn.text = "GIRAR";
            wheel.Toggle = false;
        }
    }
}
