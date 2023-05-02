using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject KeyMap;


    private void Start() {
        pauseMenu.SetActive(false);
        KeyMap.SetActive(false);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && GameManager.isPaused == false)
        {
            GameManager.isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        } 
        else if(Input.GetKeyDown(KeyCode.Escape) && GameManager.isPaused == true)
        {
            GameManager.isPaused = false;
            pauseMenu.SetActive(false); 
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
        
    }
    public void resume()
    {
        GameManager.isPaused = false;
        pauseMenu.SetActive(false); 
        Cursor.visible = false;
    }

    public void Controls()
    {
        KeyMap.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.visible = true; 
    }

    public void BackToPause()
    {
        KeyMap.SetActive(false);
        pauseMenu.SetActive(true); 
    }

    public void Exit()
    {
        Application.Quit();
    }
}
