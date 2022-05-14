using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Vector2Int gridDimensions;
    // public Vector2 tileDimensions;
    public GameObject tileAsset;

    public Vector2 tileSize;

    private List<GameObject> _tiles = new();

    public delegate void GridSelect(Vector3 coords);

    public GridSelect onGridSelect;

    
    // Start is called before the first frame update
    void Start()
    {
        // start position is bottom-left corner of the grid
        // i.e. center

        for (int y = 0; y < gridDimensions.y; y++)
        {
            // this._tiles.Add(new List<GameObject>());
            
            for (int x = 0; x < gridDimensions.x; x++)
            {
                GameObject newTile = Instantiate(tileAsset, transform);
                newTile.transform.localPosition = new Vector3(x * tileSize.x, 0, y * tileSize.y);
                GridPanel panel = newTile.GetComponent<GridPanel>();
                panel.Coordinates = new Vector2(x, y);
                
                _tiles.Add(newTile);
                // _tiles[y][x]
                // _tiles.Add(newTile.GetComponent<GridPanel>());
            }
        }
    }

    public Vector3 TranslatePoint(Vector3 coords)
    {
        // foreach (GameObject tile in _tiles)
        // {
        //     if (
        //         (coords.x >= tile.transform.position.x &&
        //          coords.x < (tile.transform.position.x + tileSize.x)) &&
        //         (coords.z >= tile.transform.position.z &&
        //          coords.z < (tile.transform.position.z + tileSize.y)))
        //     {
        //         return tile.transform.position;
        //     }
        // }
        return new Vector3(
            Mathf.Floor(coords.x / tileSize.x) * tileSize.x,
            coords.y,
            Mathf.Floor(coords.z / tileSize.y) * tileSize.y
        );

        throw new ArgumentException("coordinates provided are not within the grid.");
    }

    public void GridSelection(Vector3 worldCoords)
    {
        Debug.Log("Grid World Coordinates Selected!" +  worldCoords);
        
        
        
        onGridSelect?.Invoke(worldCoords);
    }
}
