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
		inputVector = ConvertInput(inputVector);
		controlable.Move(inputVector);
	}

	private void Update()
	{
		ReadMove();
	}

	private Vector2 ConvertInput(Vector2 input)
	{
		if (input.y > 0f)
		{
			if (input.x <= -0.33f)
			{
				return new Vector2(-1, 0.5f);
			}
			if (input.x >= 0.33f)
			{
				return new Vector2(1, 0.5f);
			}
			if (input.x is > (-0.33f) and < 0.33f)
			{
				return new Vector2(0, 1);
			}
		}
		if (input.y < 0f)
		{
			if (input.x <= -0.33f)
			{
				return new Vector2(-1, -0.5f);
			}
			if (input.x >= 0.33f)
			{
				return new Vector2(1, -0.5f);
			}
			if (input.x is > (-0.33f) and < 0.33f)
			{
				return new Vector2(0, -1);
			}
		}
		return new Vector2(0, 0);
	}
}
