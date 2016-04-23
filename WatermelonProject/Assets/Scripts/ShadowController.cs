using UnityEngine;
using System.Collections;
using Util;

public class ShadowController : Singleton<ShadowController>
{
	[SerializeField] private Transform _sunBase;

	public void SetSunDirection(float direction)
	{
		Quaternion q = Quaternion.Euler(0,0,direction);
		Vector3 pos = Vector3.up*20;
		Debug.Log(direction);
		_sunBase.position = transform.position+q*pos;
	}
}
