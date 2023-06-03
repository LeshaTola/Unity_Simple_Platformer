using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
	[SerializeField] private Slider healthSlider;
	[SerializeField] private Spawner spawner;

	private Character character;

	private void Awake()
	{
		character = FindAnyObjectByType<Character>();
	}

	private void OnEnable()
	{
		if (character != null)
		{
			character.Health.OnValueChanged += OnHealthValueChanged;
		}
		spawner.OnCharacterSpawned += OnCharacterSpawned;
	}

	private void OnDisable()
	{
		if (character != null)
		{
			character.Health.OnValueChanged -= OnHealthValueChanged;
		}
		spawner.OnCharacterSpawned -= OnCharacterSpawned;
	}

	private void OnHealthValueChanged(float value)
	{
		UpdateVisual(value);
	}

	private void UpdateVisual(float value)
	{
		healthSlider.value = value;
	}

	private void OnCharacterSpawned(Character newCharacter)
	{
		character = newCharacter;
		newCharacter.Health.OnValueChanged += OnHealthValueChanged;
		UpdateVisual(newCharacter.Health.Value);
	}
}
