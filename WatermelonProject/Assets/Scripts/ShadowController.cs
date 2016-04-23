using UnityEngine;
using System.Collections;
using Util;

public class ShadowController : Singleton<ShadowController>
{
	[SerializeField] private Transform _sunBase;

	public void Update()
	{
		SetSunDirection(Time.time*30);
	}

	public void SetSunDirection(float direction)
	{
		Quaternion q = Quaternion.Euler(0,0,direction);
		Vector3 pos = Vector3.up*20;
		_sunBase.position = q*pos;
	}
}
