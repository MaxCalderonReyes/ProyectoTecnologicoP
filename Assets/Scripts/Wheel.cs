using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    private int randomvalue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;
    private bool toggle;

    [SerializeField]
    private Text textQuestion;

    public bool Toggle { get => toggle; set => toggle = value; }


    // Use this for initialization
    private void Start()
    {
        toggle = false;
        textQuestion.text = "Pregunta...";
        coroutineAllowed = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (toggle && coroutineAllowed)
            StartCoroutine(Spin());
    }
    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomvalue = Random.Range(20, 30);
        timeInterval = 0.1f;


        for (int i = 0; i < randomvalue; i++)
        {

            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomvalue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomvalue * 0.85f))
                timeInterval = 0.4f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
            transform.Rotate(0, 0, 22.5f);
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 1: ¿sabes cual ...?";
                }               
                break;
            case 45:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 2: ¿sabes cual ...?";
                }
                break;
            case 90:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 3: ¿sabes cual ...?";
                }
                break;
            case 135:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 4: ¿sabes cual ...?";
                }
                break;
            case 180:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 5: ¿sabes cual ...?";
                }
                break;
            case 225:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 6: ¿sabes cual ...?";
                }
                break;
            case 270:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 7: ¿sabes cual ...?";
                }
                break;
            case 315:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 8: ¿sabes cual ...?";
                }
                break;
        }
        coroutineAllowed = true;
    }
}
