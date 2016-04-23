using UnityEngine;
using System.Collections;
using LOS.Event;

public class PlayerLoseCondition : MonoBehaviour
{

	private bool _inShadow;

	void Start ()
	{
		LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();

		trigger.OnTriggered += OnLit;
		trigger.OnNotTriggered += OnNotLit;
	}

	private void OnNotLit()
	{
		if (Time.timeSinceLevelLoad > 0.1f)
		{
			GameManager.Instance.Die();
		}
	}

	private void OnLit()
	{

	}	
}
