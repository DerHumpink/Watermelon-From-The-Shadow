using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 2f;
	public Vector2 jumpSpeed;

	bool jumping = false;
	Rigidbody2D rb;
	bool lookingRight = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !jumping) {

			Vector2 vel = rb.velocity;

			vel.y = jumpSpeed.y;
			vel.x = (lookingRight ? 1f : -1f) * jumpSpeed.x;

			jumping = true;
		}
	}
}
