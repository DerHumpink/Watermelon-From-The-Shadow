using UnityEngine;
using System.Collections;

public class MoveCameraABit : MonoBehaviour
{

	private Vector3 _basePos;
	// Use this for initialization
	void Start ()
	{
		_basePos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = _basePos + Vector3.up*1f*Mathf.Sign(Time.time);
	}
}
