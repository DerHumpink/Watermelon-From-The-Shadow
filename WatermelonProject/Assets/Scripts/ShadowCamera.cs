using UnityEngine;
using System.Collections;

public class ShadowCamera : MonoBehaviour {
	
	void Update ()
	{
		transform.position = CameraController.Instance.transform.position;
	}
}
