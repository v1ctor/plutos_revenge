using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7f;
    public float jumpTakeoffSpeed = 7f;

    public int initialHealth;
    public float temporaryInvulnerabilityInterval = 3f;

    private float invulnerabilityStopTime;
    private bool invulnerability = false;
    private Animator playerAnimator;

    protected override void Start()
    {
        base.Start();
        GameManager.instance.Health = initialHealth;
        GameManager.instance.Player = this;
        playerAnimator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        if (invulnerability && Time.time > invulnerabilityStopTime) {
            invulnerability = false;
        }
    }

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

    public override void OnCollisionEnterPhysics(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Bullet")) {
            TakeDamage(1);
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            GameManager.instance.GameOver();
        }
    }

    private void StartInvulnerability()
    {
        invulnerability = true;
        invulnerabilityStopTime = Time.time + temporaryInvulnerabilityInterval;
        if (playerAnimator)
        {
            playerAnimator.SetTrigger("Invulnerable");
        }
    }

    public void TakeDamage(int damage)
    {
        if (invulnerability) {
            return;
        }
        GameManager.instance.Health -= damage;

        if (GameManager.instance.Health <= 0)
        {
            GameOver();
            return;
        }

        StartInvulnerability();
    }

    public void GameOver()
    {
        GameManager.instance.GameOver();
    }

    public void NextLevel()
    {
        GameManager.instance.NextLevel();
    }
}
