using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour
{
	[SerializeField] private float moveCooldown;

	private World world;
	private Movement movement;
	private CharacterVisual characterVisual;
	private float moveTimer;

	public enum EntityState
	{
		Stay,
		Move,
	}

	public EntityState State { get; private set; }

	private void Awake()
	{
		State = EntityState.Stay;
		characterVisual = GetComponentInChildren<CharacterVisual>();

		movement = GetComponent<Movement>();
		world = FindObjectOfType<World>();
		if (world == null)
		{
			throw new System.Exception($"{gameObject.name} can not find world on scene!");
		}
		movement.SetTargetPosition(transform.position);

	}

	private void OnEnable()
	{
		movement.OnMovmentEnded += OnMovmentEnded;
	}

	private void OnDisable()
	{
		movement.OnMovmentEnded -= OnMovmentEnded;
	}

	private void Update()
	{
		switch (State)
		{
			case EntityState.Stay:
				moveTimer -= Time.deltaTime;
				if (moveTimer <= 0)
				{
					Move();
				}
				break;
			case EntityState.Move:
				break;
			default:
				throw new System.Exception($"Unknown State in {gameObject.name}");
		}
	}

	private void Move()
	{
		if (State == EntityState.Stay)
		{
			State = EntityState.Move;

			Vector3 positionToCheck = world.GetAvailablePosition(transform.position, (x) => x.TileType == TileType.Yellow);
			if (world.IsPositionAvailable(positionToCheck))
			{
				movement.SetTargetPosition(positionToCheck);
				characterVisual.SetDirection(positionToCheck - transform.position);
				moveTimer = moveCooldown;
			}
		}
	}

	private void OnMovmentEnded()
	{
		State = EntityState.Stay;
	}
}
