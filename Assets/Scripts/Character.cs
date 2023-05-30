using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] private float moveSpeed;

	private CharacterVisual characterVisual;
	private Vector3 targetTilePosition;

	public enum CharacterState
	{
		Stay,
		Move,
	}

	public CharacterState State { get; private set; }

	private void Awake()
	{
		State = CharacterState.Stay;
		characterVisual = GetComponentInChildren<CharacterVisual>();
		MoveToTile(transform.position);
	}

	private void Update()
	{
		switch (State)
		{
			case CharacterState.Stay:

				break;
			case CharacterState.Move:
				MoveIternal();

				if (transform.position == targetTilePosition)
				{
					State = CharacterState.Stay;
				}
				break;
			default:
				throw new System.Exception($"Unknown State in {gameObject.name}");
		}
	}

	public void MoveToTile(Vector3 tilePosition)
	{
		if (State == CharacterState.Stay)
		{
			State = CharacterState.Move;
			targetTilePosition = tilePosition;
		}
	}

	private void MoveIternal()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetTilePosition, moveSpeed);
		characterVisual.SetDirection(targetTilePosition - transform.position);
	}

}
