using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public GameObject target;
    public float speed = 7f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
	}
}
