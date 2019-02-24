using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, collision.transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Player")) { 

        }

        Destroy(collision.gameObject);

    }
}
