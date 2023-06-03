using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	public event Action<float> OnValueChanged;
	public event Action OnDeath;

	[SerializeField] private float maxValue;
	[SerializeField] private float value;

	public float Value => value;

	private void Start()
	{
		OnValueChanged?.Invoke(value / maxValue);
	}

	public void ApplyDamage(float damage)
	{
		value -= damage;

		if (value <= 0)
		{
			Destroy(gameObject);
			OnDeath?.Invoke();
		}
		OnValueChanged?.Invoke(value / maxValue);
	}

	public bool IsAlive()
	{
		return value > 0;
	}
}
