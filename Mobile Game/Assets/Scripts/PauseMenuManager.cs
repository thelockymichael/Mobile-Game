using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour {

    public GameObject PausePanel;

    public GameObject InControl;

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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
