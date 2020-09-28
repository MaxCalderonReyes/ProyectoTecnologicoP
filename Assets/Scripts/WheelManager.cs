using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    private Wheel wheel;
    private int numberCorrectAnswers;
    private float timerShowCongratulations;

    [SerializeField]
    private Button btnSpin;
    [SerializeField]
    private Text textBtnSpin;
    [SerializeField]
    private Text result;
    [SerializeField]
    private Text textCorrectAnswers;

    [SerializeField]
    private Button option1;
    [SerializeField]
    private Button option2;
    [SerializeField]
    private Button option3;

    [SerializeField]
    private GameObject panelCongratulations;
    [SerializeField]
    private Button btnNextLevel;

    [SerializeField]
    private string RptaP1, RptaP2, RptaP3, RptaP4, RptaP5, RptaP6, RptaP7, RptaP8;


    private void Awake()
    {
        wheel = GameObject.FindGameObjectWithTag("Wheel").GetComponent<Wheel>();
    }
    // Start is called before the first frame update
    void Start()
    {
        textBtnSpin.text = "GIRAR";
        result.text = "";
        numberCorrectAnswers = 0;
        timerShowCongratulations = 0;
        textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        textCorrectAnswers.gameObject.SetActive(false);
        panelCongratulations.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wheel.ShowOptions == true)
        {
            option1.gameObject.SetActive(true);
            option2.gameObject.SetActive(true);
            option3.gameObject.SetActive(true);
        }
        else
        {
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
        }

        if (numberCorrectAnswers == 3)
        {
            btnSpin.interactable = false;
            timerShowCongratulations += Time.deltaTime;
            if (timerShowCongratulations >= 1.5f)
            {
                RuletaMusic.instance.win();
                panelCongratulations.SetActive(true);
            }
        }
    }
    public void Spin()
    {        
        if (wheel.Toggle == false)
        {
            result.text = "";
            wheel.TextQuestion.text = "Pregunta...";
            wheel.ShowOptions = false;
            option1.interactable = true;
            option2.interactable = true;
            option3.interactable = true;

            textBtnSpin.text = "PARAR";
            wheel.Toggle = true;
        }
        else
        {
            textBtnSpin.text = "GIRAR";
            wheel.Toggle = false;
            btnSpin.interactable = false;
        }
    }

    public void CheckAnswer(Text textBtn)
    {
        string correctAnswer = "";
        textCorrectAnswers.gameObject.SetActive(true);
        option1.interactable = false;
        option2.interactable = false;
        option3.interactable = false;
        btnSpin.interactable = true;

        switch (wheel.FinalAngle)
        {
            case 0:
                correctAnswer = RptaP1;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;

                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 45:
                correctAnswer = RptaP2;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 90:
                correctAnswer = RptaP3;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 135:
                correctAnswer = RptaP4;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 180:
                correctAnswer = RptaP5;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 225:
                correctAnswer = RptaP6;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 270:
                correctAnswer = RptaP7;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
            case 315:
                correctAnswer = RptaP8;
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "Incorrecto";
                }
                break;
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
