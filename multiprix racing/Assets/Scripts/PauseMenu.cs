using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Home(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("title_screen");
        isPaused = false;
    }
    public void Update(){
        if(isPaused){
            PlayerPrefs.SetInt("IsPaused", 1);
        }
        else{
            PlayerPrefs.SetInt("IsPaused", 0);
        }
    }
}
