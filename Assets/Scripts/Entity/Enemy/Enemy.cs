using UnityEngine;

public class Enemy : MonoBehaviour
{

	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveCooldown;

	[Header("Patrol settings")]
	[SerializeField] private Transform patrolPoint;
	[SerializeField] private float patrolRadius;

	private CharacterVisual characterVisual;
	private float moveTimer;
	private Vector3 targetPosition;

	private void Awake()
	{
		characterVisual = GetComponentInChildren<CharacterVisual>();
	}

	private void Update()
	{
		moveTimer -= Time.deltaTime;
		if (moveTimer <= 0)
		{
			Move();
		}
	}

	private void FixedUpdate()
	{
		MoveIternal();
	}

	private void Move()
	{
		moveTimer = moveCooldown;
		targetPosition = patrolPoint.position + new Vector3(Random.Range(0, patrolRadius), Random.Range(0, patrolRadius), 0f);
	}

	private void MoveIternal()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
		characterVisual.SetDirection(targetPosition - transform.position);
	}
}
