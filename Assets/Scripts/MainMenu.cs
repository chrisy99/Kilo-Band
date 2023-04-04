using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{   
    private int previousSceneIndex; 

    private void Awake(){            // keeps game object
    }

    private void Start(){           // Sets current active scene as the previous scene
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartGame() {       //changes scene to start of game
        LevelLoader.Instance.LoadNextLevel();
        //LevelLoader.Instance.LoadSpecificLevel("Game Over");
    }

    public void ReturnMainMenu() {  //changes scene to main menu
        LevelLoader.Instance.LoadSpecificLevelIndex(0);
    }

    public void RestartLevel() {  //changes scene to start of current level
        LevelLoader.Instance.LoadSpecificLevelIndex(previousSceneIndex);
    }

    public void ExitGame() {        //exits game 
        Application.Quit();
    }

}
