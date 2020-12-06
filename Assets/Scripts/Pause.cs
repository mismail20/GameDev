using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
	public static bool isGamePaused = false;

	[SerializeField] GameObject resumeButton;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject quitButton;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
        	if(isGamePaused){
        		ResumeGame();
        	}else{
        		PauseGame();
        	}
        }
    } 

    public void ResumeGame(){
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        quitButton.SetActive(false);
        Time.timeScale=1f;
        isGamePaused = false;

    }

    void PauseGame(){
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
