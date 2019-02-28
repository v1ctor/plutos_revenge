using UnityEngine;

public class EnemyController : PhysicsObject
{

    public GameObject player;
    public float speed = 3f;

    public enum EnemyType { 
        Follow,
        Walk,
    };

    public EnemyType enemyType = EnemyType.Walk;

    private Vector2 walkDirection = Vector2.left;

    protected override void ComputeVelocity()
    {
        if (enemyType == EnemyType.Follow && player)
        {
            Vector3 direction = player.transform.position - transform.position;

            targetVelocity = direction.normalized * speed;
        } else {
            targetVelocity = walkDirection * speed;
        }
    }

    public override void OnCollisionEnterPhysics(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var c = collision.gameObject.GetComponent<PlayerController>();
            c.TakeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyType == EnemyType.Walk)
        {
            if (collision.gameObject.CompareTag("Boundry"))
            {
                if (walkDirection == Vector2.left)
                {
                    walkDirection = Vector2.right;
                }
                else
                {
                    walkDirection = Vector2.left;
                }
            }
        }
    }
}
