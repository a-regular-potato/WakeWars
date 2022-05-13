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
    
    private NavMeshAgent _agent;
    
   
    // Start is called before the first frame update
    void Start()
    {
        name = "USS " + _nameSuggestions[Random.Range(0, _nameSuggestions.Length)];
        
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination(Vector3 coords)
    {
        this._agent.SetDestination(coords);
    }

    bool TakeDamage(int damage)
    {
        health -= damage;
        return health <= 0;
    }
    
    [SuppressMessage("ReSharper", "StringLiteralTypo")] private readonly string[] _nameSuggestions = new string[]{"Curzon", "Supreme", "Disdain", "Disgust", "Flying Fish", "Rapscallion", "Valhalla"};
}
