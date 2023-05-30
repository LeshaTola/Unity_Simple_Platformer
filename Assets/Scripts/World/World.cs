using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class World : MonoBehaviour
{
	private List<Tile> tiles;

	private void Awake()
	{
		tiles = new List<Tile>();
		tiles.AddRange(GetComponentsInChildren<Tile>());
	}

	public bool IsPositionAvailable(Vector3 postion)
	{
		Tile tileToCheck = tiles.FirstOrDefault((x) => x.transform.position == postion);
		return tileToCheck != null && tileToCheck.IsTileAvailable();
	}
}
