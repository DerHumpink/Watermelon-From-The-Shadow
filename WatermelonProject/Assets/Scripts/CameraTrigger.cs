using System;
using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour
{
	[SerializeField] public RangeFloat Range;
	[SerializeField] public float LerpFactor;

	private void Start()
	{
		CameraController.Instance.CameraTriggers.Add(this);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0,0.2f,0.8f,0.4f);
		Vector3 center = Vector3.right*Range.Center;
		Vector3 size = new Vector3(Range.Size, 10, 0);
		Gizmos.DrawCube(center, size);
	}
}

[Serializable]
public struct RangeFloat
{
	public float Min, Max;
	public float Center { get { return Mathf.Lerp(Min, Max, 0.5f); } }
	public float Size { get { return Max-Min;} }

	public bool Contains(float playerPos)
	{
		return playerPos > Min && playerPos < Max;
	}
}
