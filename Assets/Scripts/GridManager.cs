using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Vector2Int gridDimensions;
    // public Vector2 tileDimensions;
    public GameObject tileAsset;

    public Vector2 tileSize;

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
                
                // _tiles[y][x]
                // _tiles.Add(newTile.GetComponent<GridPanel>());
            }
        }
    }

    public void GridSelection(Vector3 worldCoords)
    {
        Debug.Log("Grid World Coordinates Selected!" +  worldCoords);
        
        
        
        onGridSelect?.Invoke(worldCoords);
    }
}
