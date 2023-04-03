using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{   
    private int previousSceneIndex; 

    private void Awake(){            // keeps game object
        DontDestroyOnLoad(gameObject);
    }

    private void Start(){           // Sets current active scene as the previous scene
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartGame() {       //changes scene to start of game
        SceneManager.LoadScene(1);
    }

    public void ReturnMainMenu() {  //changes scene to main menu
        SceneManager.LoadScene(0);
    }

    public void RestartLevel() {  //changes scene to main menu
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void ExitGame() {        //exits game 
        Application.Quit();
    }

}
