using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    public Vector2 Coordinates { get; set; }
    private Renderer _renderer;
    private GridManager _manager;
    private static readonly int Highlighted = Shader.PropertyToID("_Highlighted");
    private static readonly int Selected = Shader.PropertyToID("_Selected");

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _manager = GetComponentInParent<GridManager>();
    }

    private void OnMouseEnter()
    {
        _renderer.material.SetInt(Highlighted, 1);
    }

    private void OnMouseExit()
    {
        _renderer.material.SetInt(Highlighted, 0);
    }

    private void OnMouseDown()
    {
        _renderer.material.SetInt(Selected, 1);
    }

    private void OnMouseUp()
    {
        _manager.GridSelection(transform.position);
        _renderer.material.SetInt(Selected, 0);

    }
}
