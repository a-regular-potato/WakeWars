using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public string Statisitcs;
    public Module module;
    public ToolTipManager tipManager;

    public bool Selected;
    public Clickable SelectedObj;
    private Clickable HitObj;
    private GameObject HitObjObj;
    private Renderer rend;

    public Color SelectedColour;
    public Color DeSelectedColour;

    private Clickable[] clickables;

    private Camera Cam;

    bool AnySelected()
    {
        foreach(Clickable clickable in clickables)
        {
            if (clickable.Selected)
            {
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        rend = this.GetComponentInChildren<Renderer>();
        if(rend == null)
        {
            rend = this.GetComponent<Renderer>();
        }
        clickables = FindObjectsOfType<Clickable>();
        Cam = GameObject.Find("Player").GetComponentInChildren<Camera>();
        tipManager = GameObject.Find("Canvas").GetComponent<ToolTipManager>();
    }

 

    private void OnMouseOver()
    {
        var ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            HitObj = hit.transform.gameObject.GetComponent<Clickable>();
            HitObjObj = hit.transform.gameObject;
        }
        if (HitObjObj.CompareTag("Module"))
        {
            module = HitObj.GetComponent<Module>();
            if(module.shipClass.ToString() == "WEAPON")
            {
                Statisitcs = module.WeaponData.AllStats;
            }
            if(module.shipClass.ToString() == "STORAGE")
            {
                Statisitcs = module.StorageData.AllStats;
            }
            tipManager.ShowInfo(Statisitcs, Input.mousePosition);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!AnySelected())
                {
                    rend.material.SetColor("_OutlineColour", SelectedColour);
                    Selected = true;
                    SelectedObj = this;
                }
                else
                {
                    if (HitObj == SelectedObj)
                    {
                        rend.material.SetColor("_OutlineColour", DeSelectedColour);
                        Selected = false;
                        SelectedObj = null;
                    }
                    else
                    {
                        foreach (Clickable clickable in clickables)
                        {
                            clickable.rend.material.SetColor("_OutlineColour", DeSelectedColour);
                            clickable.rend.material.SetFloat("_OutlineWidth", 0f);
                            clickable.Selected = false;
                            clickable.SelectedObj = null;
                        }
                        rend.material.SetColor("_OutlineColour", SelectedColour);
                        rend.material.SetFloat("_OutlineWidth", 4f);
                        SelectedObj = this;
                        Selected = true;
                    }
                }
            }
        }       
    }
    private void OnMouseEnter()
    {
        rend.material.SetFloat("_OutlineWidth", 4f);
    }
    private void OnMouseExit()
    {
        if (!Selected)
        {
            rend.material.SetFloat("_OutlineWidth", 0f);
        }
        tipManager.HideInfo();
    }
}
