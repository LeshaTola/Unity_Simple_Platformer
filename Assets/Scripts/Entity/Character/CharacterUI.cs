using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
	[SerializeField] private Slider healthSlider;
	[SerializeField] private Health characterHealth;

	private void OnEnable()
	{
		characterHealth.OnValueChanged += OnHealthValueChanged;
	}

	private void OnDisable()
	{
		characterHealth.OnValueChanged -= OnHealthValueChanged;
	}

	private void OnHealthValueChanged(float value)
	{
		UpdateVisual(value);
	}

	private void UpdateVisual(float value)
	{
		healthSlider.value = value;
	}
}
