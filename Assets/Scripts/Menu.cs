using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
   
    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exit()
    {

        Application.Quit();

    }
}
