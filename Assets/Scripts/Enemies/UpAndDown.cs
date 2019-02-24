using UnityEngine;

public class UpAndDown : MonoBehaviour {

    public float amplitude = 1.0f;

    private float startTime;

    void OnEnable() {
        // To always start from zero
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        float enabledTime = Time.time - startTime;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + Mathf.Sin(enabledTime) * amplitude);
	}
}
