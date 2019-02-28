using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int Health { set; get; }
    public int BossHealth
    {
        get
        {
            return currentBoss.health;
        }
    }

    private BossController currentBoss = null;

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

    public void StartBossFight(BossController boss)
    {
        currentBoss = boss;
    }

    public bool HasBoss()
    {
        return currentBoss != null;
    }

    public void GameOver()
    {
        currentBoss = null;
        GameSceneManager.instance.RestartLevel();
    }

    public void NextLevel()
    {
        currentBoss = null;
        GameSceneManager.instance.NextLevel();
    }

}
