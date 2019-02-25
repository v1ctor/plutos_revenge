using Boo.Lang;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance = null;

    public string[] levels;
    public string transitionScene;
    public string endGameScene;
    public string mainMenuScene;

    private int currentLevel;

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

    public void NewGame()
    {
        ChangeLevel(0);
    }

    public void RestartLevel() {
        ChangeLevel(currentLevel);
    }

    public void NextLevel() {
        currentLevel++;
        ChangeLevel(currentLevel);
    }

    public void Load()
    {
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(levels[currentLevel]);
        } else {
            SceneManager.LoadScene(endGameScene);
        }
    }

    private void ChangeLevel(int levelId)
    {
        SceneManager.LoadScene(transitionScene);
    }

}
