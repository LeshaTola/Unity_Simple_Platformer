using UnityEngine;

public class Character : MonoBehaviour, IControlable
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private World world;

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

		world = FindObjectOfType<World>();
		if (world == null)
		{
			throw new System.Exception($"{gameObject.name} can not find world on scene!");
		}
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

	private void MoveIternal()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetTilePosition, moveSpeed);
		characterVisual.SetDirection(targetTilePosition - transform.position);
	}

	private Vector2 ConvertInput(Vector2 input)
	{
		if (input.y > 0f)
		{
			if (input.x <= -0.33f)
			{
				return new Vector2(-1, 0.5f);
			}
			if (input.x >= 0.33f)
			{
				return new Vector2(1, 0.5f);
			}
			if (input.x is > (-0.33f) and < 0.33f)
			{
				return new Vector2(0, 1);
			}
		}
		if (input.y < 0f)
		{
			if (input.x <= -0.33f)
			{
				return new Vector2(-1, -0.5f);
			}
			if (input.x >= 0.33f)
			{
				return new Vector2(1, -0.5f);
			}
			if (input.x is > (-0.33f) and < 0.33f)
			{
				return new Vector2(0, -1);
			}
		}
		return new Vector2(0, 0);
	}

	public void Move(Vector3 direction)
	{
		if (State == CharacterState.Stay)
		{
			State = CharacterState.Move;

			Vector3 convertedInput = ConvertInput(direction);
			Vector3 positionToCheck = transform.position + convertedInput;
			if (world.IsPositionAvailable(positionToCheck))
			{
				targetTilePosition = positionToCheck;
			}
		}
	}
}
