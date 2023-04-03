using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public GameObject player;
    public float score;
    public float timer;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    public float Score()
    {
        if (timer >= 180)
        {
            score += 0;
        }
        else
        {
            score += ((180 - timer) * 100);
        }
        return score;
    }
}