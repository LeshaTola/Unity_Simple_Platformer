using UnityEngine;

public class Controller : MonoBehaviour
{
	private IControlable controlable;
	private GameInput gameInput;

	private void Awake()
	{
		controlable = GetComponent<IControlable>();
		gameInput = new GameInput();
		gameInput.Character.Enable();
	}

	private void ReadMove()
	{
		Vector2 inputVector = gameInput.Character.Movement.ReadValue<Vector2>();
		controlable.Move(inputVector);
	}

	private void Update()
	{
		ReadMove();
	}
}
