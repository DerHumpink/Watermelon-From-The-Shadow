using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			GameManager.Instance.SetPlayerSafe (true);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			GameManager.Instance.SetPlayerSafe (false);
		}
	}
}
