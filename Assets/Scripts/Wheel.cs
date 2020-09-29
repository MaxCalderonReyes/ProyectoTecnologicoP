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

    [SerializeField]
    private string Pregunta1, Alternativa1A, Alternativa1B, Alternativa1C,
                   Pregunta2, Alternativa2A, Alternativa2B, Alternativa2C,
                   Pregunta3, Alternativa3A, Alternativa3B, Alternativa3C,
                   Pregunta4, Alternativa4A, Alternativa4B, Alternativa4C,
                   Pregunta5, Alternativa5A, Alternativa5B, Alternativa5C,
                   Pregunta6, Alternativa6A, Alternativa6B, Alternativa6C,
                   Pregunta7, Alternativa7A, Alternativa7B, Alternativa7C,
                   Pregunta8, Alternativa8A, Alternativa8B, Alternativa8C;



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
                    textQuestion.text = "Pregunta 1: " + Pregunta1;
                    textOption1.text = Alternativa1A;
                    textOption2.text = Alternativa1B;
                    textOption3.text = Alternativa1C;
                    showOptions = true;
                }               
                break;
            case 45:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 2: " + Pregunta2;
                    textOption1.text = Alternativa2A;
                    textOption2.text = Alternativa2B;
                    textOption3.text = Alternativa2C;
                    showOptions = true;
                }
                break;
            case 90:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 3: " + Pregunta3;
                    textOption1.text = Alternativa3A;
                    textOption2.text = Alternativa3B;
                    textOption3.text = Alternativa3C;
                    showOptions = true;
                }
                break;
            case 135:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 4: " + Pregunta4;
                    textOption1.text = Alternativa4A;
                    textOption2.text = Alternativa4B;
                    textOption3.text = Alternativa4C;
                    showOptions = true;
                }
                break;
            case 180:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 5: " + Pregunta5;
                    textOption1.text = Alternativa5A;
                    textOption2.text = Alternativa5B;
                    textOption3.text = Alternativa5C;
                    showOptions = true;
                }
                break;
            case 225:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 6: " + Pregunta6;
                    textOption1.text = Alternativa6A;
                    textOption2.text = Alternativa6B;
                    textOption3.text = Alternativa6C;
                    showOptions = true;
                }
                break;
            case 270:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 7: " + Pregunta7;
                    textOption1.text = Alternativa7A;
                    textOption2.text = Alternativa7B;
                    textOption3.text = Alternativa7C;
                    showOptions = true;
                }
                break;
            case 315:
                if (toggle == false)
                {
                    textQuestion.text = "Pregunta 8: " + Pregunta8;
                    textOption1.text = Alternativa8A;
                    textOption2.text = Alternativa8B;
                    textOption3.text = Alternativa8C;
                    showOptions = true;
                }
                break;
        }
        coroutineAllowed = true;
    }
}
