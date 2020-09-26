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
                correctAnswer = "1.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "1.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "1.Incorrecto";
                }
                break;
            case 45:
                correctAnswer = "2.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "2.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "2.Incorrecto";
                }
                break;
            case 90:
                correctAnswer = "3.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "3.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "3.Incorrecto";
                }
                break;
            case 135:
                correctAnswer = "4.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "4.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "4.Incorrecto";
                }
                break;
            case 180:
                correctAnswer = "5.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "5.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "5.Incorrecto";
                }
                break;
            case 225:
                correctAnswer = "6.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "6.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "6.Incorrecto";
                }
                break;
            case 270:
                correctAnswer = "7.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "7.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "7.Incorrecto";
                }
                break;
            case 315:
                correctAnswer = "8.A";
                if (textBtn.text.Equals(correctAnswer))
                {
                    result.text = "8.Correcto";
                    numberCorrectAnswers++;
                    textCorrectAnswers.text = "Respuestas correctas: " + numberCorrectAnswers;
                }
                else
                {
                    result.text = "8.Incorrecto";
                }
                break;
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Game2");
    }
}
