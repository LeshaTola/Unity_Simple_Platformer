using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField] private TileType tileType;
	[SerializeField] private bool walkable;

	public bool IsTileAvailable()
	{
		return walkable;
	}
}
