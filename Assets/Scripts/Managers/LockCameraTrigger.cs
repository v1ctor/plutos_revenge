using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCameraTrigger : MonoBehaviour {

    public Camera mainCamera;

    private CameraManager manager;

    void Start()
    {
        manager = mainCamera.GetComponent<CameraManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.Lock(gameObject.transform.position);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.Unlock();
        }
    }
}
