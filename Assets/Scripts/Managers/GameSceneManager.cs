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
    private string sceneName;

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

    public void MainMenu() {
        currentLevel = 0;
        StartCoroutine(ChangeLevel(mainMenuScene));
    }

    public void NewGame()
    {
        currentLevel = 0;
        sceneName = levels[currentLevel];
        SceneManager.LoadScene(transitionScene);
    }

    public void RestartLevel()
    {
        StartCoroutine(ChangeLevel(sceneName));
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel < levels.Length)
        {
            sceneName = levels[currentLevel];
        } else {
            sceneName = endGameScene;
        }
        StartCoroutine(ChangeLevel(sceneName));
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator ChangeLevel(string sceneId)
    {
        sceneName = sceneId;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(transitionScene);
    }

}
