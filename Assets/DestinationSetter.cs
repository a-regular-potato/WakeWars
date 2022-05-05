using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationSetter : MonoBehaviour
{
    public Camera PCam;

    public bool LocationSetting;

    NavMeshAgent agent;

    private void Start()
    {
        PCam = GameObject.Find("Player").GetComponentInChildren<Camera>();
        this.agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        var ray = PCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (LocationSetting)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(Physics.Raycast(ray, out hit))
                {
                    this.agent.SetDestination(new Vector3(hit.point.x, this.transform.position.y, hit.point.z));
                    LocationSetting = false;
                }
            }
        }
    }
}
