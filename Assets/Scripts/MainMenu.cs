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

        SceneManager.LoadScene(0);

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
            Time.timeScale=(paused) ? 0 : 1;
            Panel.SetActive(paused);
        }
 
       
    }
}

