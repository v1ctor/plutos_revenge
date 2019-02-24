using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.TriggerBossFight();
            //SceneManager.LoadScene("Level2");
        }
    }
}
