using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShoot : MonoBehaviour
{

    public GameObject projectile;
    public float cooldown = 5f;
    public float interval = 1f;
    public float power = 10f;
    public int amount = 3;
    public int count = 3;

    private float nextFireBurst;
    private int currentBurst;
    private float nextBurst;


    void OnEnable()
    {
        nextFireBurst = Time.time + cooldown;
        nextBurst = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFireBurst)
        {
            nextFireBurst = Time.time + cooldown;
            currentBurst = 0;
            nextBurst = Time.time;
        }

        if (currentBurst < count && Time.time >= nextBurst)
        {
            nextBurst = Time.time + interval;
            currentBurst++;
            FireBurst();
        }
    }

    void FireBurst()
    {

        float angle = Mathf.PI / 2;

        float step = angle / amount;

        int mid = amount / 2;


        for (int i = -mid; i <= mid; i++)
        {

            int direction = transform.rotation.y < 0.001f ? 1 : -1;
            Vector2 velocity = Vector2.left * power * direction;

            velocity.y = Mathf.Sin(i * step) * power;

            Vector3 position = transform.position;

            position.y += i;

            GameObject newProjectile = Instantiate(projectile, position, Quaternion.identity);


            newProjectile.GetComponent<Rigidbody2D>().AddForce(velocity);
        }

    }
}
