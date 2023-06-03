using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public event Action<Character> OnCharacterSpawned;

	[SerializeField] private List<Transform> spawnLocations;
	[SerializeField] private GameObject characterPrefab;
	[SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;

	private Character character;

	private void Awake()
	{
		character = FindObjectOfType<Character>();
	}

	private void OnEnable()
	{
		if (character == null)
		{
			Spawn(spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count)].position);
		}
		else
		{
			character.GetComponent<Health>().OnDeath += OnCharacterDeath;
		}
	}

	private void OnDisable()
	{
		if (character != null)
		{
			character.GetComponent<Health>().OnDeath -= OnCharacterDeath;
		}
	}

	public void Spawn(Vector3 spawnLocation)
	{
		GameObject ch = Instantiate(characterPrefab, spawnLocation, Quaternion.identity);
		character = ch.GetComponent<Character>();

		OnCharacterSpawned?.Invoke(character);
		virtualCamera.Follow = character.transform;

		character.GetComponent<Health>().OnDeath += OnCharacterDeath;
	}

	private void OnCharacterDeath()
	{
		character.GetComponent<Health>().OnDeath -= OnCharacterDeath;
		Spawn(spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count)].position);
	}
}
