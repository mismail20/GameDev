using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseScript : MonoBehaviour
{
	public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject quitButton;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            Debug.Log("ESC Down");

        	if(isGamePaused){
        		ResumeGame();
        	}else{
        		PauseGame();
        	}
        }
    } 
    
    //Starts everything from the game
    public void ResumeGame(){
        Manager.GameManager.track.Play();
        pauseMenu.SetActive(false);
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        quitButton.SetActive(false);
        Time.timeScale=1f;
        isGamePaused = false;

    }

    //Pauses the game
    void PauseGame(){
        Manager.GameManager.paused = true;
        Manager.GameManager.track.Pause();
        pauseMenu.SetActive(true);
        resumeButton.SetActive(true);
        menuButton.SetActive(true);
        quitButton.SetActive(true);
        Time.timeScale=0f;
        isGamePaused = true;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();

        Debug.Log("Quit");
    }



}
