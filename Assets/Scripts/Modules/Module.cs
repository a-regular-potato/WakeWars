using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public Renderer[] rends;

    public Color SelectedColour;
    public Color UnSelectedColour;

    public GenericData ModuleData;
    [System.Serializable]
    public class GenericData
    {
        public ShipClass ModuleClass;
        public ModClass Class;
        [Space]        
        public float UpgradeState;
        public float MaxUpgradeAmount;
        [Space]
        public float CurrentHealth;
        public float MaxHealth;
        [Space]
        public ModStatus Status;
        public enum ShipClass
        {
            WEAPON,
            STORAGE,
            ENGINE,
            RADAR,
            ARMOUR,
            VEHICLEBAY,
        }
        public enum ModClass
        {
            MK1,
            MK2,
            MK3,
            MK4,
            MK5,
            MK6,
        }
        public enum ModStatus
        {
            FULLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
    }
}
