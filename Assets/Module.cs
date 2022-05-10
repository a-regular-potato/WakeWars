using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public Renderer[] rends;

    public Color SelectedColour;
    public Color UnSelectedColour;

    public ShipClass shipClass;
    public enum ShipClass
    {
        WEAPON,
        STORAGE,
        ENGINE,
        RADAR,
        ARMOUR,
        VEHICLEBAY,
    }
    public Weapon WeaponData;
    public Storage StorageData;
    public Engine EngineData;
    public Radar RadarData;
    public Armour ArmourData;
    public VehicalBay VehicalBayData;

    [System.Serializable]
    public class Weapon
    {
        public Class ModClass;
        public Status ModStatus;
        public enum Status
        {
            FULLY_OPERATIONAL,
            MOSTLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
        public enum Class
        {
            MK1,
            MK2,
            MK2_5,
            MK3,
            MK4,
            MK5,
        }
        [Range(0,3)]
        public int UpgradeState = 0;
        [Space]
        public float Health;
        public float MaxHealth;
        [Space]
        public float Damage;
        public float Range;
        public float Accuracy;
        public float ReloadSpeed;
        public float MaxShots;
        [Space]
        public bool AutoAim = true;

        public string AllStats;
    }
    [System.Serializable]
    public class Storage
    {
        public Class ModClass;
        public Status ModStatus;
        public enum Status
        {
            FULLY_OPERATIONAL,
            MOSTLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
        public enum Class
        {
            MK1,
            MK2,
            MK3,
        }
        [Range(0, 3)]
        public int UpgradeState = 0;
        [Space]
        public float Health;
        public float MaxHealth;
        [Space]
        public float StorageLeft;
        public float MaxStorage;

        public string AllStats;
    }
    [System.Serializable]
    public class Engine
    {
        public Class ModClass;
        public Status ModStatus;
        public enum Status
        {
            FULLY_OPERATIONAL,
            MOSTLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
        public enum Class
        {
            MK1,
            MK2,
            MK3,
            MK4,
        }
        [Range(0, 3)]
        public int UpgradeState = 0;
        [Space]
        public float Health;
        public float MaxHealth;
        [Space]
        public float Speed;
        public float MaxSpeed;
        public float Power;
        public float Fuel;
        public float MaxFuel;

        public string AllStats;
    }
    [System.Serializable]
    public class Radar
    {
        public Class ModClass;
        public Status ModStatus;
        public enum Status
        {
            FULLY_OPERATIONAL,
            MOSTLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
        public enum Class
        {
            MK1,
            MK2,
            MK3,
        }
        [Range(0, 3)]
        public int UpgradeState = 0;
        [Space]
        public float Health;
        public float MaxHealth;
        [Space]
        public float Range;
        public float Accuracy;
        public float ResetTime;
        [Space]
        public Type ScanType;
        public enum Type
        {
            SWAY,
            PULSE,
        }

        public string AllStats;
    }
    [System.Serializable]
    public class Armour
    {
        public Class ModClass;
        public Status ModStatus;
        public enum Status
        {
            FULLY_OPERATIONAL,
            MOSTLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
        public enum Class
        {
            MK1,
            MK2,
            MK3,
            MK4,
            MK5,
            MK6,
        }
        [Range(0, 3)]
        public int UpgradeState = 0;
        [Space]
        public float Health;
        public float MaxHealth;
        [Space]
        public float Resistance;
        public float DepthResistance;
        public float BlastResistance;
        public float BulletResistance;

        public string AllStats;
    }
    [System.Serializable]
    public class VehicalBay
    {
        public Class ModClass;
        public Status ModStatus;
        public enum Status
        {
            FULLY_OPERATIONAL,
            MOSTLY_OPERATIONAL,
            DAMAGED,
            OFFLINE,
        }
        public enum Class
        {
            MK1,
            MK2,
        }
        [Range(0, 3)]
        public int UpgradeState = 0;
        [Space]
        public float Health;
        public float MaxHealth;
        [Space]
        public float Storage;
        public float LaunchSpeed;

        public string AllStats;
    }
    private void Start()
    {
        WeaponData.AllStats = "Type : " + shipClass + "\n Class : " + WeaponData.ModClass + "\n Status : " + WeaponData.ModStatus + "\n Health : " + WeaponData.Health + "/" + WeaponData.MaxHealth + "\n Damage : " + WeaponData.Damage + "\n Accuracy : " + WeaponData.Accuracy + "\n Range : " + WeaponData.Range + "\n ReloadSpeed : " + WeaponData.ReloadSpeed + "\n MaxShots : " + WeaponData.MaxShots + "\n UpgradeState : " + WeaponData.UpgradeState;
        StorageData.AllStats = "Type : " + shipClass + "\n Class : " + StorageData.ModClass + "\n Status : " + StorageData.ModStatus + "\n Health : " + StorageData.Health + "/" + StorageData.MaxHealth + "\n Storage : " + StorageData.StorageLeft + "/" + StorageData.MaxStorage + "\n UpgradeState : " + StorageData.UpgradeState;
    }
}
