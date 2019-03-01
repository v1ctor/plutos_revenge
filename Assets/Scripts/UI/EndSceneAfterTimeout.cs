using System.Collections;
using UnityEngine;

public class EndSceneAfterTimeout : MonoBehaviour {

    public float duration = 3f;
    public Animator animator;

    private float endTime;
    private bool ended = false;

	// Use this for initialization
	void Start () {
        endTime = Time.time + duration;
	}
	
	// Update is called once per frame
	void Update () {
		if (!ended && endTime < Time.time) {
            ended = true;
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene() {
        if (animator)
        {
            animator.SetTrigger("End");
            yield return new WaitForSeconds(1f);
            GameSceneManager.instance.Load();
        } else {
            GameSceneManager.instance.NextLevel();
        }

    }
}
