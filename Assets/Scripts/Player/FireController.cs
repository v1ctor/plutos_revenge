using UnityEngine;

public class FireController : MonoBehaviour
{

    public float power = 10f;

    public GameObject projectile;
    public AudioClip shotSound;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            int direction = 1;
            if (player && player.goingLeft) {
                direction = -1;
            }

            newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * power * direction);
            SoundManager.instance.PlayClip(shotSound, 0.7f);
        }
    }
}
