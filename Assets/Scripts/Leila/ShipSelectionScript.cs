using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipSelectionScript : MonoBehaviour
{
    public bool Selected;
    public bool SelectedModule;
    public bool ModuleSelect;
    
    [HideInInspector]
    public GameObject CurrentSeleced;

    [HideInInspector]
    public GameObject CurrentSelectedModule;


    private GameObject HitObj;

    private Camera PCam;

    private ShipData hitShipData;
    private Module hitModuleData;
    private ShipData selectedShipData;
    private Module selectedModuleData;

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
            if (Selected)
            {
                if (ModuleSelect)
                {
                    if (HitObj.CompareTag("Module"))
                    {
                        foreach(GameObject Module in selectedShipData.attatchedModules)
                        {
                            if(Module == HitObj)
                            {
                                hitModuleData = HitObj.GetComponent<Module>();
                                foreach (Renderer rend in hitModuleData.rends)
                                {
                                    rend.material.SetFloat("_OutlineWidth", 4f);
                                }
                                if (Input.GetMouseButtonDown(0))
                                {
                                    if (SelectedModule)
                                    {
                                        if (HitObj = CurrentSelectedModule)
                                         {
                                            DeSelectModule();
                                        }
                                        else
                                        {
                                            DeSelectModule();
                                            SelectModule();
                                        }
                                    }
                                    else
                                    {
                                        SelectModule();
                                    }
                                }
                            }
                        }                        
                    }
                    else
                    {
                        if(hitModuleData != null)
                        {
                            foreach (Renderer rend in hitModuleData.rends)
                            {
                                rend.material.SetFloat("_OutlineWidth", 0f);
                            }
                        }
                    }
                }
            }
            if (HitObj.CompareTag("Ship"))
            {
                hitShipData = HitObj.GetComponent<ShipData>();
                hitShipData.HighlightRend.material.SetFloat("_OutlineWidth", 5f);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Selected)
                    {
                        if (CurrentSeleced == HitObj)
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
            else if (HitObj.CompareTag("Module")) { }
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

            if (!ModuleSelect)
            {
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
        }

        if (Selected)
        {
            selectedShipData.HighlightRend.material.SetFloat("_OutlineWidth", 4f);
            selectedShipData.HighlightRend.material.SetColor("_OutlineColour", selectedShipData.SelectedColour);
        }

        if (SelectedModule)
        {
            foreach(Renderer rend in selectedModuleData.rends)
            {
                rend.material.SetFloat("_OutlineWidth", 4f);
                rend.material.SetColor("_OutlineColour", selectedModuleData.SelectedColour);
            }
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
        if (ModuleSelect)
        {
            DeSelectModule();
        }
        ModuleSelect = false;
    }

    void SelectModule()
    {
        CurrentSelectedModule = HitObj;
        selectedModuleData = CurrentSelectedModule.GetComponent<Module>();
        SelectedModule = true;
    }

    void DeSelectModule()
    {
        SelectedModule = false;
        CurrentSelectedModule = null;
        foreach(Renderer rend in selectedModuleData.rends)
        {
            rend.material.SetFloat("_OutlineWidth", 0f);
            rend.material.SetColor("_OutlineColour", selectedModuleData.UnSelectedColour);
        }        
    }
}
