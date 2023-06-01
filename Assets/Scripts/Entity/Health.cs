using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	public event Action<float> OnValueChanged;

	[SerializeField] private float maxValue;
	[SerializeField] private float value;

	private void Start()
	{
		OnValueChanged?.Invoke(value / maxValue);
	}

	public void ApplyDamage(float damage)
	{
		value -= damage;

		value = value < 0 ? 0 : value;

		OnValueChanged?.Invoke(value / maxValue);
	}

	public bool IsAlive()
	{
		return value > 0;
	}
}
