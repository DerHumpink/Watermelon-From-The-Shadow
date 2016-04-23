using UnityEngine;
using System.Collections;
using Util;

public class CameraController : Singleton<CameraController> {

	
	void Update ()
	{
		transform.position = Movement.Instance.transform.position;
	}
}
