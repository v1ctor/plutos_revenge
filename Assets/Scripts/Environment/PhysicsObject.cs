using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = 0.65f;
    public float gravityModifier = 1.0f;

    private Rigidbody2D rb2d;
    protected Vector2 velocity;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] raycasts = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    private bool goingLeft = false;

    void OnEnable()
    {
        goingLeft = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
        if (!goingLeft && targetVelocity.x < 0.0f)
        {
            gameObject.transform.Rotate(Vector3.up, 180);
            goingLeft = true;
        } else if (goingLeft && targetVelocity.x > 0.0f)
        {
            gameObject.transform.Rotate(Vector3.up, 180);
            goingLeft = false;
        }
    }

    // Use this for initialization
    void Start () {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;
        grounded = false;


        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
	}

    protected virtual void ComputeVelocity() { }

    void Movement(Vector2 move, bool yMovement) {
        float distance = move.magnitude;
        if (distance > minMoveDistance) {
            int count = rb2d.Cast(move, contactFilter, raycasts, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++) {
                hitBufferList.Add(raycasts[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++) {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY) {
                    grounded = true;
                    if (yMovement) {
                        groundNormal = currentNormal;
                        groundNormal.x = 0f;
                    }

                }
                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0f) {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = distance > modifiedDistance ? modifiedDistance : distance;
            }

        }
        rb2d.position += move.normalized * distance;
    }
}
