using UnityEngine;

public class MenuHandler : MonoBehaviour {

    public void NewGame() {
        GameSceneManager.instance.NewGame();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
