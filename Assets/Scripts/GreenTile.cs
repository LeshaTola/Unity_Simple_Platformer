using System;
using UnityEngine;

public class GreenTile : MonoBehaviour
{
	private Character character;

	private float tileDistance = 1.12f;


	private void Awake()
	{
		character = FindAnyObjectByType<Character>();
		if (character == null)
		{
			throw new Exception("There is no Character on scene");
		}
	}

	private void OnMouseDown()
	{
		if (Vector3.Distance(transform.position, character.transform.position) <= tileDistance)
		{
			character.MoveToTile(transform.position);
		}
		else
		{
			Debug.Log("ToFar");
		}
	}
}
