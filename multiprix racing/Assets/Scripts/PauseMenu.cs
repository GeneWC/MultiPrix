using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    public TMP_InputField inputField;
    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        inputField.DeactivateInputField();
        inputField.interactable = false;

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        inputField.ActivateInputField();
        inputField.Select();
        inputField.interactable = true;
        inputField.text = "";
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
