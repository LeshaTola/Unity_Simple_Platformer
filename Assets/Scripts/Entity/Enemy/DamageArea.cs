using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DamageArea : MonoBehaviour, IDamager
{
	[SerializeField] private float damageValue;
	[SerializeField] private float damageCooldown;
	[SerializeField] private float damageRadius;

	private float damageTimer;
	private CircleCollider2D damageArea;

	private void Awake()
	{
		damageArea = GetComponent<CircleCollider2D>();
		damageArea.isTrigger = true;
		damageArea.radius = damageRadius;
	}

	private void Update()
	{
		damageTimer -= Time.deltaTime;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (damageTimer <= 0)
		{
			if (collision.TryGetComponent(out IDamageable character))
			{
				character.ApplyDamage(damageValue, this);
				damageTimer = damageCooldown;
			}
		}
	}
}
