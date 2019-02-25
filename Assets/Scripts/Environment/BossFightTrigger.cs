using UnityEngine;

public class BossFightTrigger : MonoBehaviour
{

    public GameObject boss;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.instance.TriggerBossFight();
            //SceneManager.LoadScene("Level2");
            boss.SetActive(true);
        }
    }
}
