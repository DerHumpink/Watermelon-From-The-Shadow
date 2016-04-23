using UnityEngine;
using System.Collections;

public class Watermelon : MonoBehaviour {

	Animator anim;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	public void Change() {
		anim.SetTrigger ("transition");
	}
}
