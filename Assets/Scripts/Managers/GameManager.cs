using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int Health { set; get; }
    public PlayerController Player { set; get; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        GameSceneManager.instance.RestartLevel();
    }

    public void NextLevel()
    {
        GameSceneManager.instance.NextLevel();
    }

}
