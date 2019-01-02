using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    private  static LevelManager instance;

    public static LevelManager Instance { get { return instance; } }

    public GameObject PausePanel;

    public GameObject InControl;

    // Use this for initialization
    void Start()
    {
        instance = this;
        PausePanel.SetActive(false);
        InControl.SetActive(true);
    }

    public void Victory()
    {
       // Debug.Log("YOU HAVE WON");

    }

    public void pauseGame()
    {
        PausePanel.SetActive(true);
        InControl.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ResumeToGame()
    {
        PausePanel.SetActive(false);
        InControl.SetActive(true);
        Time.timeScale = 1.0f;

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("mainMenu");
        // PausePanel.SetActive(false);
        // InControl.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1.0f;
    }

    public void GoToSettings()
    {
        // settingsMenu.SetActive(true)
    }

}
