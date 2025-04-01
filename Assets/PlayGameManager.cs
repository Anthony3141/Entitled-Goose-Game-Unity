using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class PlayGameManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject deathMenu;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.000001f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public void DeathScreen()
    {
        Time.timeScale = 0.000001f;
        deathMenu.SetActive(true);
    }
    public void winningScreen()
    {
        Time.timeScale = 0.000001f;
        winScreen.SetActive(true);
    }
}
