using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Vector2Int gridSize;
    public GameObject tilePrefab;
    public Vector2 tileSize;
    private GameObject[][] _tiles;

    public delegate void GridSelect(Vector3 worldCoords, Vector2Int gridCoords);
    public delegate void GridHover(Vector3 worldCoords, Vector2Int gridCoords);

    public GridHover OnGridHover;
    public GridSelect OnGridSelect;

    
    // Start is called before the first frame update
    private void Start()
    {
        // Construct TileMap
        _tiles = new GameObject[gridSize.y][];

        for (int y = 0; y < gridSize.y; y++)
        {
            _tiles[y] = new GameObject[gridSize.x];
            for (int x = 0; x < gridSize.x; x++)
            {
                _tiles[y][x] = Instantiate(
                    tilePrefab, 
                    new Vector3(
                        tileSize.x * (x + 1), 
                        transform.position.y, 
                        tileSize.y * (y + 1)), 
                    new Quaternion(), 
                    transform); // parent is the grid manager.
            }
        }

        Vector3 worldCoords = Project(new Vector2Int(0, 0));
        Debug.Log("Test Projection 1 (0, 0) = " + worldCoords);
        Debug.Log("Test Projection 2 (2, 0) = " + Project(new Vector2Int(2, 0)));
        Debug.Log("Test Projection 3 (0, 5) = " + Project(new Vector2Int(0, 5)));
    }

    public Vector3 Project(Vector2Int position)
    {
        Vector3 worldPos = _tiles[position.y][position.x].transform.position;
        Debug.Log("[PROJECT] World Pos: " + worldPos);
        return new Vector3(
            worldPos.x + (tileSize.x / 2),
            0,
            worldPos.z + (tileSize.y / 2)
        );
    }

    public Vector2Int Unproject(Vector3 worldLocation)
    {
        int x = (int) Math.Round(worldLocation.x / tileSize.x),
            y = (int) Math.Round(worldLocation.z / tileSize.y);

        return new Vector2Int(x, y);
    }


    public void GridSelection(Vector3 worldCoords)
    {
        
        // Debug.Log("World Space Coordinates Selected!" +  worldCoords);
        // Debug.Log("Grid Space Coordinates Selected!" +  Unproject(worldCoords));
        
        OnGridSelect?.Invoke(worldCoords, Unproject(worldCoords));
    }
    
    public void GridHovered(Vector3 worldCoords)
    {
        
        // Debug.Log("World Space Coordinates Hovered!" +  worldCoords);
        // Debug.Log("Grid Space Coordinates Hovered!" +  Unproject(worldCoords));
        
        OnGridSelect?.Invoke(worldCoords, Unproject(worldCoords));
    }
}
