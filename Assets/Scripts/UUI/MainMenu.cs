using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    private bool paused = false;

    void Start()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }

    public void exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        paused = false;
        Panel.SetActive(false);
        Time.timeScale = 1;

    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
        
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
       

    }

    public void Quit()
    {

        Application.Quit();
    }

    public void MainPause()
    {
        Panel.SetActive(true);
        paused = !paused;
        
 
        if (paused)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

