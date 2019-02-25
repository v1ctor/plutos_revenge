using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);

        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Player")) {
            GameManager.instance.TakeDamage(1);
        } else if (collision.gameObject.CompareTag("Boss")) {
            GameManager.instance.GameOver();
        }

        Destroy(gameObject);
    }
}
