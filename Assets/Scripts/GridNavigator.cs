using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridNavigator : MonoBehaviour
{
    private NavMeshAgent _agent;

    private GridManager _gm;

    private Queue<Vector3> _gridNavPath;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _gm = FindObjectOfType<GridManager>();
    }

    private void FixedUpdate()
    {
        switch (_agent.pathStatus)
        {
            case NavMeshPathStatus.PathComplete:
                if (_gridNavPath is { Count: > 0 })
                {
                    _agent.SetDestination(_gridNavPath.Dequeue());
                }

                break;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        _agent.isStopped = true;
        
        bool success = _agent.CalculatePath(destination, path);
        if (!success)
            throw new ArgumentOutOfRangeException(nameof(destination), "could not be found. is it even on the grid!?");

        
        Vector3[] origCoords = path.corners;
        _gridNavPath = new Queue<Vector3>();

        foreach (var coord in origCoords)
        {
            Vector3 gridSpaceCoord = _gm.TranslatePoint(coord);
            _gridNavPath.Enqueue(gridSpaceCoord);
            Debug.Log($"navmesh corner translated - from {coord} to {gridSpaceCoord} on grid");
        }

        if (_gridNavPath.Count > 0)
            _agent.SetDestination(_gridNavPath.Dequeue());
        _agent.isStopped = false;
    }
}
