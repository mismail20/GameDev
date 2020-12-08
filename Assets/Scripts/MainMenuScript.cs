using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void startFunction()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("LevelSelector");
    }

    public void QuitGame(){
        Application.Quit(); 
    }
}
