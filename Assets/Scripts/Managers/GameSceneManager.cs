using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
        SceneManager.LoadScene(transitionScene);
    }

    public void RestartLevel() {
        StartCoroutine(ChangeLevel(currentLevel));
    }

    public void NextLevel() {
        currentLevel++;
        StartCoroutine(ChangeLevel(currentLevel));
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

    private IEnumerator ChangeLevel(int levelId)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(transitionScene);
    }

}
