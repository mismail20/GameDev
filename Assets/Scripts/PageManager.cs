using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    // Start is called before the first frame update

    //This Script concerns the changing of the page in regards to every subscreen of the main menu

    // The next 4 methods change the scene to a different level and are all called on click of the appropriate button
    public void Level1()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Game");
    }
    
    public void Level2()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Game1");
    }

    public void Level3()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Game2");
    }

    public void LevelRandom()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Game3");
    }

    public void LevelMenu()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("LevelSelector1");
    }

    // Return to main menu function
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}

