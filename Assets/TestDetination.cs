using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestDetination : MonoBehaviour
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();

        this.agent.SetDestination(new Vector3(2500, this.transform.position.y, 2500));
    }

    private void Update()
    {
        // transform.rotation = new Quaternion(0.682237029f,-0.0112641789f,0.0214082561f,-0.730730832f);
        
    }
}
