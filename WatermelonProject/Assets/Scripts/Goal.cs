using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			GameManager.Instance.Win();
		}
	}
}
