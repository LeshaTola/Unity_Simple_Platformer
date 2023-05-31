using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class World : MonoBehaviour
{
	private List<Tile> tiles;
	private List<Vector3> availableDirections = new()
	{
		 new Vector3(-1f, 0.5f,0),
		 new Vector3(0f,1f,0),
		 new Vector3(1f, 0.5f,0),
		 new Vector3(1f, -0.5f,0),
		 new Vector3(0f,-1f,0),
		 new Vector3(-1f, -0.5f,0),
	};

	public ReadOnlyCollection<Vector3> AvailableDirections => availableDirections.AsReadOnly();

	private void Awake()
	{
		tiles = new List<Tile>();
		tiles.AddRange(GetComponentsInChildren<Tile>());
	}

	public bool IsPositionAvailable(Vector3 postion)
	{
		Tile tileToCheck = GetTileFromPosition(postion);
		return tileToCheck != null && tileToCheck.IsTileAvailable();
	}

	private List<Tile> GetAvailableTiles(Vector3 postion)
	{
		List<Tile> result = new();
		foreach (Vector3 dir in availableDirections)
		{
			Tile tile = GetTileFromPosition(postion + dir);
			if (tile != null)
			{
				result.Add(tile);
			}
		}
		return result;
	}

	private Tile GetTileFromPosition(Vector3 postion)
	{
		return tiles.FirstOrDefault((x) => x.transform.position == postion);
	}

	public delegate bool TileDelegate(Tile tile);

	public Vector3 GetAvailablePosition(Vector3 position, TileDelegate requirement)
	{
		List<Tile> tilesToCheck = GetAvailableTiles(position);
		List<Tile> correctTiles = new();
		foreach (Tile tile in tilesToCheck)
		{
			if (requirement(tile))
			{
				correctTiles.Add(tile);
			}
		}

		return correctTiles[Random.Range(0, correctTiles.Count)].transform.position;
	}
}
