using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    public Vector3 movement;
    public float speed;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        movement = Vector3.zero;
        movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0 , Input.GetAxis("Vertical") * speed);
        if (movement != Vector3.zero)
        {
            rb.AddForce(movement);
        }
	}
}
