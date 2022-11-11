using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;

public class Ship : MonoBehaviour
{
    public new string name;
    public int health = 100;
    public List<Module> modules;
    public bool selectable;

    private GridNavigator _navigator;

    private GridManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GridManager>();

        name = "USS " + _nameSuggestions[Random.Range(0, _nameSuggestions.Length)];
        
        _navigator = GetComponent<GridNavigator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination(Vector3 coords)
    {
        _navigator.HighlightPath(coords);
        // _navigator.SetDestination(coords);
    }

    // IEnumerator SnapDestination(Vector3 coords)
    // {
    //     
    //     _agent.SetDestination(coords);
    //     yield return new WaitForEndOfFrame();
    //     _agent.isStopped = true;
    //
    //     Vector3[] agentPath = _agent.path.corners;
    //     Vector3[] gridCoords = new Vector3[agentPath.Length];
    //
    //     for (int i = 0; i < agentPath.Length; i++)
    //     {
    //         Vector3 gridSpacePoint = _gm.TranslatePoint(agentPath[i]);
    //         Debug.Log("sits on grid tile at " + gridSpacePoint);
    //         gridCoords[i] = gridSpacePoint;
    //
    //     }
    //
    //     _agent.SetDestination(gridCoords[0]);
    //     _agent.isStopped = false;
    // }

    bool TakeDamage(int damage)
    {
        health -= damage;
        return health <= 0;
    }
    
    [SuppressMessage("ReSharper", "StringLiteralTypo")] private readonly string[] _nameSuggestions = new string[]{"Curzon", "Supreme", "Disdain", "Disgust", "Flying Fish", "Rapscallion", "Valhalla"};
}
