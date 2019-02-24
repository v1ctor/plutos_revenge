using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject prefab;
    public GameObject player;
    public float period = 10f;
    private float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > startTime + period)
        {
            GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
            EnemyController ec = go.GetComponent<EnemyController>();
            if (ec) {
                ec.player = player;
            }
            startTime = Time.time;
        }
    }
}
