using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkUntilBoundry : PhysicsObject {

    public float speed = 5f;

    private Vector2 direction = Vector2.left;

    protected override void ComputeVelocity() {
        targetVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundry")) { 
            if (direction == Vector2.left) {
                direction = Vector2.right;
            } else {
                direction = Vector2.left;
            }
        }
    }

}
