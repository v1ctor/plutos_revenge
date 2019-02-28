using UnityEngine;

public class BossFightTrigger : MonoBehaviour
{

    public GameObject boss;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!GameManager.instance.HasBoss())
            {
                var c = boss.GetComponent<BossController>();
                GameManager.instance.StartBossFight(c);
                boss.SetActive(true);
            }
        }
    }
}
