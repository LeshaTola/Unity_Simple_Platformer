using UnityEngine;
using UnityEngine.Tilemaps;

public class Hide : MonoBehaviour
{

	private TilemapRenderer tilemapRenderer;

	private void Start()
	{
		tilemapRenderer = GetComponent<TilemapRenderer>();
		tilemapRenderer.enabled = false;
	}
}