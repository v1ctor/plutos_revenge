using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);

        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Boss")) {
            // TODO move to boss if it's killed
            GameManager.instance.NextLevel();
        } else if (collision.gameObject.CompareTag("Player")) {
            GameManager.instance.Player.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
