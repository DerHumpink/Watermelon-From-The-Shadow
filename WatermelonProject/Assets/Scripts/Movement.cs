using UnityEngine;
using System.Collections;

public class Movement : Util.Singleton<Movement> {

	const float MIN_AXIS = 0.1f;

	public float speed = 2f;
	public Vector2 jumpSpeed;

	bool jumping = false;
	Rigidbody2D rb;
	bool lookingRight = true;

	Vector2 lastAxis;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 axis;
		axis.x = Input.GetAxis ("Horizontal");
		axis.y = Input.GetAxis ("Vertical");


		Vector2 vel = rb.velocity;

		if (axis.y > MIN_AXIS && lastAxis.y <= MIN_AXIS && !jumping)
		{
			vel.y = jumpSpeed.y;
			//vel.x = (lookingRight ? 1f : -1f) * jumpSpeed.x;

			jumping = true;
		}

		if (!jumping||vel.x<2)
		{
			if (Mathf.Abs(axis.x) > 0.1f)
			{
				if (Mathf.Sign(axis.x) != Mathf.Sign(vel.x))
				{
					vel.x = speed * axis.x*2.5f;
				}
				else
				{
					vel.x = speed * axis.x;
				}
			}
			else
			{
				vel.x = 0f;
			}
		}

		rb.velocity = vel;
		lastAxis = axis;
	}

	void OnCollisionEnter2D (Collision2D col) {
		jumping = false;
	}
}
