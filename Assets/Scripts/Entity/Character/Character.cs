using UnityEngine;
using static Enemy;

[RequireComponent(typeof(Movement))]

public class Character : MonoBehaviour, IControlable
{

	private World world;
	private CharacterVisual characterVisual;
	private Movement movement;

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

				break;
			case EntityState.Move:

				break;
			default:
				throw new System.Exception($"Unknown State in {gameObject.name}");
		}
	}

	public void Move(Vector3 direction)
	{
		if (State == EntityState.Stay)
		{
			State = EntityState.Move;

			Vector3 positionToCheck = transform.position + direction;
			if (world.IsPositionAvailable(positionToCheck))
			{
				movement.SetTargetPosition(positionToCheck);
				characterVisual.SetDirection(positionToCheck - transform.position);
			}
		}
	}

	private void OnMovmentEnded()
	{
		State = EntityState.Stay;
	}
}
