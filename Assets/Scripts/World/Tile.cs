using UnityEngine;

namespace world
{
	public class Tile : MonoBehaviour
	{
		[SerializeField] private TileType tileType;
		[SerializeField] private bool walkable;

		public TileType TileType => tileType;

		public bool IsTileAvailable()
		{
			return walkable;
		}
	}
}
