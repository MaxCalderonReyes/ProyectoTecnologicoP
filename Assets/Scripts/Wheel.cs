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
    private bool showOptions;

    [SerializeField]
    private Text textQuestion;

    [SerializeField]
    private Text textOption1;
    [SerializeField]
    private Text textOption2;
    [SerializeField]
    private Text textOption3;
    

    public bool Toggle { get => toggle; set => toggle = value; }
    public bool ShowOptions { get => showOptions; set => showOptions = value; }
    public int FinalAngle { get => finalAngle; set => finalAngle = value; }
    public Text TextQuestion { get => textQuestion; set => textQuestion = value; }


   

    // Use this for initialization
    private void Start()
    {
        toggle = false;
        showOptions = false;
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
                    textOption1.text = "1.A";
                    textOption2.text = "1.B";
                    textOption3.text = "1.C";
                    showOptions = true;
                }               
                break;
            case 45:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 2: ¿sabes cual ...?";
                    textOption1.text = "2.A";
                    textOption2.text = "2.B";
                    textOption3.text = "2.C";
                    showOptions = true;
                }
                break;
            case 90:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 3: ¿sabes cual ...?";
                    textOption1.text = "3.A";
                    textOption2.text = "3.B";
                    textOption3.text = "3.C";
                    showOptions = true;
                }
                break;
            case 135:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 4: ¿sabes cual ...?";
                    textOption1.text = "4.A";
                    textOption2.text = "4.B";
                    textOption3.text = "4.C";
                    showOptions = true;
                }
                break;
            case 180:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 5: ¿sabes cual ...?";
                    textOption1.text = "5.A";
                    textOption2.text = "5.B";
                    textOption3.text = "5.C";
                    showOptions = true;
                }
                break;
            case 225:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 6: ¿sabes cual ...?";
                    textOption1.text = "6.A";
                    textOption2.text = "6.B";
                    textOption3.text = "6.C";
                    showOptions = true;
                }
                break;
            case 270:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 7: ¿sabes cual ...?";
                    textOption1.text = "7.A";
                    textOption2.text = "7.B";
                    textOption3.text = "7.C";
                    showOptions = true;
                }
                break;
            case 315:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 8: ¿sabes cual ...?";
                    textOption1.text = "8.A";
                    textOption2.text = "8.B";
                    textOption3.text = "8.C";
                    showOptions = true;
                }
                break;
        }
        coroutineAllowed = true;
    }
}
