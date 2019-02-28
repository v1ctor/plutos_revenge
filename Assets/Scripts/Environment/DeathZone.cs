using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, collision.transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            var c = collision.gameObject.GetComponent<PlayerController>();
            c.GameOver();

        }
        else
        {

            Destroy(collision.gameObject);
        }

    }
}
