using System.Collections;
using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
	private string[] staticDirections =
	{
		"Static_N",
		"Static_NW",
		"Static_W",
		"Static_SW",
		"Static_S",
		"Static_SE",
		"Static_E",
		"Static_NE",
	};

	private string[] runDirections =
{
		"Run_N",
		"Run_NW",
		"Run_W",
		"Run_SW",
		"Run_S",
		"Run_SE",
		"Run_E",
		"Run_NE",
	};

	private Animator animator;
	private int lastDirection;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}


	public void SetDirection(Vector3 direction)
	{
		string[] directionArray = null;

		if (direction.magnitude < 0.01)
		{
			directionArray = staticDirections;
		}
		else
		{
			directionArray = runDirections;

			lastDirection = DirectionToIndex(direction);
		}

		animator.Play(directionArray[lastDirection]);
	}


	private int DirectionToIndex(Vector2 direction)
	{
		Vector2 norDir = direction.normalized;

		float step = 360 / 8;
		float offset = step / 2;

		float angle = Vector2.SignedAngle(Vector2.up, norDir);

		angle += offset;

		if (angle < 0)
		{
			angle += 360;
		}

		float stepCount = angle / step;
		return Mathf.FloorToInt(stepCount);
	}

	public IEnumerator Flash(Color color)
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		for (int i = 0; i < 3; i++)
		{
			renderer.color = color;
			yield return new WaitForSeconds(0.2f);
			renderer.color = Color.white;
			yield return new WaitForSeconds(0.2f);
		}
	}

}
