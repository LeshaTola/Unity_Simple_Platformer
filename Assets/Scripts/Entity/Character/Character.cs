using UnityEngine;

public class Character : MonoBehaviour, IControlable, IDamageable
{
	[SerializeField] private float moveSpeed;

	private CharacterVisual characterVisual;
	private Rigidbody2D rb;
	private Vector3 moveDirection;

	private void Awake()
	{
		characterVisual = GetComponentInChildren<CharacterVisual>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		MoveInternal();
	}

	public void Move(Vector3 direction)
	{
		moveDirection = direction;
	}

	public void ApplyDamage(float damage, IDamager sender)
	{
		Health Health = GetComponent<Health>();
		Health.ApplyDamage(damage);
		StartCoroutine(characterVisual.Flash(Color.red));
	}

	private void MoveInternal()
	{
		Vector3 velocity = moveDirection * moveSpeed;
		Vector3 worldVelocity = transform.TransformVector(velocity);

		characterVisual.SetDirection(moveDirection);
		rb.velocity = worldVelocity;
	}
}
