using UnityEngine;
using System.Collections;

public class SunMovement : MonoBehaviour {

	public Vector3 startPoint;
	public Vector3 endPoint;
	public float curveHeight = 2f;
	public float movementFactor = 1f;
	public float direction = 1f;

	Transform player;
	Vector3 lastPlayerPosition = Vector3.zero;
	Vector3 currentWantedPosition;

	// Use this for initialization
	void Start () {
		player = Movement.Instance.transform;
		lastPlayerPosition = player.position;
		currentWantedPosition = direction < 0f? endPoint : startPoint;
	}
	
	// Update is called once per frame
	void Update () {
		float movementAmount = Mathf.Abs(player.position.x - lastPlayerPosition.x) * movementFactor;


		currentWantedPosition.x += movementAmount * direction;

		if (direction > 0) { // going right
			if (currentWantedPosition.x >= endPoint.x) {
				currentWantedPosition.x = endPoint.x;

				direction = -1f;
			}
		}
		else { // going left
			if (currentWantedPosition.x <= startPoint.x) {
				currentWantedPosition.x = startPoint.x;

				direction = 1f;
			}
		}

		Vector3 aux = transform.position;
		float movementWidth = endPoint.x - startPoint.x;
		float xFactor = (currentWantedPosition.x - startPoint.x) / movementWidth;
		aux.x = Mathf.Lerp(startPoint.x, endPoint.x, Easing.Quadratic.InOut (xFactor));
		aux.y = Mathf.Lerp(startPoint.y, endPoint.y, Easing.Quadratic.InOut (xFactor)) +
			Mathf.Lerp(curveHeight, 0f, Easing.Quadratic.In(Mathf.Abs((xFactor - 0.5f)*2f)));

		transform.position = aux;

		lastPlayerPosition = player.position;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (startPoint, 0.7f);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (endPoint, 0.7f);
	}
}
