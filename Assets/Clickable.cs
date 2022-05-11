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
            if(module != null)
            {
                Statisitcs = " Type : " + module.ModuleData.ModuleClass + "\n Class : " + module.ModuleData.Class + "\n Health : " + module.ModuleData.CurrentHealth + "/" + module.ModuleData.MaxHealth + "\n Status : " + module.ModuleData.Status + "\n UpgradeState : " + module.ModuleData.UpgradeState + "/" + module.ModuleData.MaxUpgradeAmount;
                if(HitObjObj.GetComponent<WeaponModule>() != null)
                {
                    WeaponModule WeaponMod = HitObjObj.GetComponent<WeaponModule>();
                    Statisitcs += "\n \n Damage : " + WeaponMod.WeaponData.Damage + "\n Range : " + WeaponMod.WeaponData.Range + "\n Accuracy : " + WeaponMod.WeaponData.Accuracy + "\n Reload Speed : " + WeaponMod.WeaponData.ReloadSpeed + "\n Shots : " + WeaponMod.WeaponData.Shots;
                }
                if(HitObjObj.GetComponent<StorageModule>() != null)
                {
                    StorageModule storageMod = HitObjObj.GetComponent<StorageModule>();
                    Statisitcs += "\n \n Storage : " + storageMod.StorageData.StorageLeft + "/" + storageMod.StorageData.StorageCapcity;
                }
                if(HitObjObj.GetComponent<EngineModule>() != null)
                {
                    EngineModule engineMod = HitObjObj.GetComponent<EngineModule>();
                    Statisitcs += "\n\n Speed : " + engineMod.EngineData.Speed + "\n Power : " + engineMod.EngineData.Power + "\n Fuel : " + engineMod.EngineData.CurrentFuel + "/" + engineMod.EngineData.MaxFuel;
                }
                if(HitObjObj.GetComponent<RadarModule>() != null)
                {
                    RadarModule radarMod = HitObjObj.GetComponent<RadarModule>();
                    Statisitcs += "\n\n Range : " + radarMod.RadarData.Range + "\n Accuracy : " + radarMod.RadarData.Accuracy + "\n\n Type : " + radarMod.RadarData.type + "\n Reset Speed : " + radarMod.RadarData.ResetSpeed;
                }
                if(HitObjObj.GetComponent<VehicalBayModule>() != null)
                {
                    VehicalBayModule vehicalBayMod = HitObjObj.GetComponent<VehicalBayModule>();
                    Statisitcs += "\n\n Capacity : " + vehicalBayMod.VehicalBayData.CapacityLeft + "/" + vehicalBayMod.VehicalBayData.TotalCapacity + "\n\n Launch Speed : " + vehicalBayMod.VehicalBayData.LaunchSpeed;
                }
                if(HitObjObj.GetComponent<ArmourModule>() != null)
                {
                    ArmourModule armourMod = HitObjObj.GetComponent<ArmourModule>();
                    Statisitcs += "\n\n Blast Protection : " + armourMod.ArmourData.BlastProtection + "\n ProjectileProtection : " + armourMod.ArmourData.ProjectileProtection + "\n Depth Protection : " + armourMod.ArmourData.DepthProtection + "\n\n Total Protection : " + armourMod.ArmourData.TotalProtection;
                }
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
