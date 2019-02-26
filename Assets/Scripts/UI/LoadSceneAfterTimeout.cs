using System.Collections;
using UnityEngine;

public class LoadSceneAfterTimeout : MonoBehaviour {

    public float duration = 3f;
    public string sceneName;

    private float endTime;

	// Use this for initialization
	void Start () {
        endTime = Time.time + duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (endTime < Time.time) {
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene() {
        yield return new WaitForSeconds(1f);
        GameSceneManager.instance.Load(sceneName);
    }
}
