using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipSelectionScript : MonoBehaviour
{
    public bool Selected;
    
    [HideInInspector]
    public GameObject CurrentSeleced;


    private GameObject HitObj;

    private Camera PCam;

    private ShipData hitShipData;
    private ShipData selectedShipData;

    private void Start()
    {
        PCam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        var ray = PCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            HitObj = hit.transform.gameObject;
            if (HitObj.CompareTag("Ship"))
            {
                hitShipData = HitObj.GetComponent<ShipData>();
                hitShipData.HighlightRend.material.SetFloat("_OutlineWidth", 5f);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Selected)
                    {
                        if(CurrentSeleced == HitObj)
                        {
                            DeSelect();
                        }
                        else
                        {
                            DeSelect();
                            Select();
                        }
                    }
                    else
                    {
                        Select();
                    }                    
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Selected)
                        DeSelect();
                }
                if (hitShipData != null)
                {
                    hitShipData.HighlightRend.material.SetFloat("_OutlineWidth", 0f);
                }               
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (Selected)
                {
                    if (!selectedShipData.Moving())
                    {
                        selectedShipData.agent.SetDestination(new Vector3(hit.point.x, CurrentSeleced.transform.position.y, hit.point.z));
                    }
                    else
                    {
                        Debug.LogWarning("Ship Still Moving, wait before trying to move again!");
                    }
                }
            }
        }

        if (Selected)
        {
            selectedShipData.HighlightRend.material.SetFloat("_OutlineWidth", 4f);
            selectedShipData.HighlightRend.material.SetColor("_OutlineColour", selectedShipData.SelectedColour);
        }
    }

    void Select()
    {
        CurrentSeleced = HitObj;        
        selectedShipData = CurrentSeleced.GetComponent<ShipData>();
        Selected = true;
    }

    void DeSelect()
    {
        Selected = false;
        CurrentSeleced = null;
        selectedShipData.HighlightRend.material.SetFloat("_OutlineWidth", 0f);
        selectedShipData.HighlightRend.material.SetColor("_OutlineColour", selectedShipData.DeSelectedColour);
    }
}
