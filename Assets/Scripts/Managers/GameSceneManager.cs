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

    public void NewGame()
    {
        currentLevel = 0;
        sceneName = levels[currentLevel];
        SceneManager.LoadScene(transitionScene);
    }

    public void RestartLevel() {
        StartCoroutine(ChangeLevel(sceneName));
    }

    public void NextLevel() {
        currentLevel++;
        if (currentLevel < levels.Length)
        {
            sceneName = levels[currentLevel];
        }
        StartCoroutine(ChangeLevel(sceneName));
    }

    public void Load(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Load()
    {
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(sceneName);
        } else {
            SceneManager.LoadScene(endGameScene);
        }
    }

    private IEnumerator ChangeLevel(string sceneId)
    {
        sceneName = sceneId;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(transitionScene);
    }

}
