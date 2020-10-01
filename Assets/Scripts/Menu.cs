using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void play()
    {
        SceneManager.LoadScene("Game1");
    }

    public void exit()
    {

        Application.Quit();
    }


    public void menu()
    {

        SceneManager.LoadScene("Menu");

    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }





}
