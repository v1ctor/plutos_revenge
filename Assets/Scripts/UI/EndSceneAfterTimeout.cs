using System.Collections;
using UnityEngine;

public class EndSceneAfterTimeout : MonoBehaviour {

    public float duration = 3f;
    public Animator animator;

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
        animator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        GameSceneManager.instance.Load();
    }
}
