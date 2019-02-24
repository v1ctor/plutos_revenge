using UnityEngine;

public class EnemyController : PhysicsObject {

    public GameObject player;
    public float speed = 3f;

    protected override void ComputeVelocity() {
        if (player)
        {
            Vector3 direction = player.transform.position - transform.position;

            targetVelocity = direction.normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            GameManager.instance.TakeDamage(1);
        }
    }
}
