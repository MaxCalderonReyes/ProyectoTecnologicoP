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
    }

    void Update()
    {
        MainPause();
    }

    public void exit()
    {
        Application.Quit();
    }

    public void Resume()
    {

        paused = false;
    }

    public void Reiniciar()
    {

        SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
    }

    public void Menu()
    {

        SceneManager.LoadScene("Menu");

    }

    public void Quit()
    {

        Application.Quit();
    }




    public void MainPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

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

