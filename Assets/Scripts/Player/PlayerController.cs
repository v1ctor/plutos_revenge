using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7f;
    public float jumpTakeoffSpeed = 7f;

    protected override void ComputeVelocity() {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded) {
            velocity.y = jumpTakeoffSpeed;
        } else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0f) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        targetVelocity = move * maxSpeed;
    }

    protected override void OnCollisionEnterPhysics(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            GameManager.instance.TakeDamage(1);
        } else if (collision.gameObject.CompareTag("Boss")) {
            GameManager.instance.GameOver();
        }
    }
}
