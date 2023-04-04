using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public static LevelLoader Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        //else if (Instance != this)
        //{
        //    Destroy(GameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //transition.SetTrigger("Rest");

        //if (Input.GetMouseButtonDown(0))
        //{
        //    LoadNextLevel();
        //}
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadSpecificLevel(string LevelName)
    {
        StartCoroutine(LoadLevel(LevelName));
    }

    public void LoadSpecificLevelIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        //Play Animation
        transition.SetTrigger("Transition");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load
        SceneManager.LoadScene(LevelIndex);
    }

    IEnumerator LoadLevel(string LevelName)
    {
        //Play Animation
        transition.SetTrigger("Transition");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load
        SceneManager.LoadScene(LevelName);
    }
}
