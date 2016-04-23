using UnityEngine;
using System.Collections;

public class Movement : Util.Singleton<Movement> {

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
		Vector2 axis;
		axis.x = Input.GetAxis ("Horizontal");
		axis.y = Input.GetAxis ("Vertical");


		Vector2 vel = rb.velocity;

		if (axis.y > 0.1f && !jumping)
		{
			vel.y = jumpSpeed.y;
			vel.x = (lookingRight ? 1f : -1f) * jumpSpeed.x;

			jumping = true;
		}


		if (Mathf.Abs (axis.x) > 0.1f)
		{
			vel.x = speed * axis.x;
		}
		else {
			vel.x = 0f;
		}

		rb.velocity = vel;
	}

	void OnCollisionEnter2D (Collision2D col) {
		jumping = false;
	}
}
