using UnityEngine;

public class BossController : MonoBehaviour
{
    public int health = 10;

    public GameObject explosion;
    public AudioClip blastSound;

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 offset = Vector3.zero;
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        SoundManager.instance.PlayClip(blastSound, 1.0f);
        Destroy(gameObject);
        GameManager.instance.NextLevel();
    }
}
