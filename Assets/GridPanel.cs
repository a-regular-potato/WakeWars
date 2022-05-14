using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Services.Internal;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    public Vector2 Coordinates { get; set; }
    private Renderer _renderer;
    private GridManager _gm;

    public enum TileState 
    {
        None,
        Invalid,
        MouseOver,
        Highlight,
        Active
    }
    
    private TileState _tileState = TileState.None;
    private static readonly int TileStatus = Shader.PropertyToID("_TileStatus");

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _gm = GetComponentInParent<GridManager>();
    }

    public void ChangeState(TileState state)
    {
        // if (_tileState >= state) return;
        
        _tileState = state;
        _renderer.material.SetFloat(TileStatus, (int)state);
    }

    private void OnMouseEnter()
    {
        ChangeState(TileState.MouseOver);
    }

    private void OnMouseExit()
    {
        ChangeState(TileState.None);
    }

    private void OnMouseDown()
    {
        ChangeState(TileState.Active);
        _gm.GridSelection(transform.position);
    }

    private void OnMouseUp()
    {
        ChangeState(TileState.None);
    }

    private void OnCollisionStay(Collision collision)
    {
        ChangeState(TileState.Invalid);
    }
}
