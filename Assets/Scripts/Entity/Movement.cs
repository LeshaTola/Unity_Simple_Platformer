using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public event Action OnMovmentEnded;

	[SerializeField] private float moveSpeed;

	private CharacterVisual characterVisual;
	private Vector3 targetTilePosition;


	private void Update()
	{
		MoveIternal();

		if (transform.position == targetTilePosition)
		{
			OnMovmentEnded?.Invoke();
		}
	}

	public void SetTargetPosition(Vector3 position)
	{
		targetTilePosition = position;
	}

	private void MoveIternal()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetTilePosition, moveSpeed);
	}
}
