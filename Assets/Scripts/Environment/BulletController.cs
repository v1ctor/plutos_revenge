using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);

        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Boss")) {
            var boss = collision.gameObject.GetComponent<BossController>();
            boss.TakeDamage(1);
        } else if (collision.gameObject.CompareTag("Player")) {
            var player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
