using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class GridPanel : MonoBehaviour
{
    public Vector2 Coordinates { get; set; }
    private Renderer _renderer;
    private GridManager _gm;

    public enum TileState 
    {
        None,
        Invalid,
        Hover,
        Highlight,
        Selected
    }
    
    private TileState _tileState = TileState.None;
    private static readonly int TileStatus = Shader.PropertyToID("_TileStatus");

    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _gm = GetComponentInParent<GridManager>();

        /*RaycastHit hit;
        
        if (Physics.BoxCast(
                transform.position - (transform.forward * (_gm.tileSize.y / 2)), // position is center of tile so subtract half of height to start at back of tile.
                new Vector3(25f, 0f, 1f), // 25 units either side of X position, no height and 1 z.
                transform.forward, // forwards
                out hit,
                transform.rotation, 
                50f,
                LayerMask.GetMask("Terrain")
            ))
        {
            Debug.Log(hit.collider.tag + " - " + hit.collider.name);
            // if (hit.collider.CompareTag("Terrain"))
            ChangeState(TileState.Invalid);
        }*/
    }
    
    public void ChangeState(TileState state)
    {
        if (_tileState == state) return;
        
        _tileState = state;
        _renderer.material.SetFloat(TileStatus, (int)state);
    }

    private void OnMouseEnter()
    {
        // Only change state if there isn't already an active state.
        if (_tileState != TileState.None)
            return;
        
        ChangeState(TileState.Hover);
        _gm.GridHovered(transform.localPosition);
    }

    private void OnMouseExit()
    {
        // Only change state if the state was previously the hovered state.
        if (_tileState != TileState.Hover)
            return;
        
        ChangeState(TileState.None);
    }

    private void OnMouseDown()
    {
        // Only change state if the state was previously the hovered state.
        if (_tileState != TileState.None && _tileState != TileState.Hover)
            return;
        
        ChangeState(TileState.Selected);
        _gm.GridSelection(transform.localPosition);
    }

    private void OnMouseUp()
    {
        // Only change state if the state was previously selected.
        if (_tileState != TileState.Selected)
            return;
        
        ChangeState(TileState.None);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag + " - " + other.gameObject.name);
        if (other.gameObject.CompareTag("Terrain"))
            ChangeState(TileState.Invalid);
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag + " - " + other.gameObject.name);
        if (other.gameObject.CompareTag("Terrain"))
            ChangeState(TileState.Invalid);
    }
}
