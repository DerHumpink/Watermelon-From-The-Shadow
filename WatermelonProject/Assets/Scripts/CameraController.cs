using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Util;

public class CameraController : Singleton<CameraController>
{
	[SerializeField] private float _scrollSpeed=2;
	[SerializeField] private Vector3 _playerOffset=Vector2.up;

	public List<CameraTrigger> CameraTriggers=new List<CameraTrigger>();


	void Update ()
	{
		var playerPos = Movement.Instance.transform.position;
		var focusPoint= playerPos+ _playerOffset;

		if (CurrentCameraTrigger)
		{
			focusPoint = Vector3.Lerp(playerPos, CurrentCameraTrigger.transform.position, CurrentCameraTrigger.LerpFactor);
		}

		transform.position = Vector3.Lerp(transform.position,focusPoint,_scrollSpeed*Time.deltaTime);
	}

	public CameraTrigger CurrentCameraTrigger
	{
		get
		{
			float playerPos = Movement.Instance.transform.position.x;
			return CameraTriggers.FirstOrDefault(c => c.Range.Contains(playerPos));
		}
	}
}
