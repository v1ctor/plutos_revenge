using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager instance = null;

    public string transitionScene;
    public string firstLevel;

    private float startTime;
    private string nextLevel;

    private void Awake()
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

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        ChangeLevel(firstLevel);
    }

    public void ChangeLevel(string levelId)
    {
        nextLevel = levelId;
        SceneManager.LoadScene(transitionScene);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
