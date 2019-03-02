using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterTimeout : MonoBehaviour
{

    public float timeout;
    public List<GameObject> objects;
    public GameObject dialogueCanvas;
    public GameObject cryCanvas;
    public GameObject angerCanvas;

    private float endTime;
    private int current = 0;
    private enum State
    {
        Dialogue,
        Cry,
        Anger,
    };
    private State state = State.Dialogue;

    // Start is called before the first frame update
    void Start()
    {
        endTime = Time.time + timeout;
    }

    // Update is called once per frame
    void Update()
    {
        if (current < objects.Count && endTime < Time.time)
        {
            endTime = Time.time + timeout;
            objects[current++].SetActive(true);
        }
        if (current >= objects.Count && state != State.Cry)
        {
            state = State.Cry;
            StartCoroutine(Cry());
        }
    }

    IEnumerator Cry() {
        yield return new WaitForSeconds(2f);
        dialogueCanvas.SetActive(false);
        cryCanvas.SetActive(true);
        yield return new WaitForSeconds(2f);
        Anger();
    }

    void Anger()
    {
        cryCanvas.SetActive(false);
        angerCanvas.SetActive(true);
        //yield return new WaitForSeconds(2f);
        GameSceneManager.instance.MainMenu();
    }
}
