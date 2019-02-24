using UnityEngine;

public class FireController : MonoBehaviour {

    public float power = 10f;

    public GameObject projectile;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            int direction = transform.rotation.y < 0.001f ? 1 : -1;

            newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * power * direction);
        }
    }
}
