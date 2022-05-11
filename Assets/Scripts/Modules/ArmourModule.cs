using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourModule : Module
{
    public Armour ArmourData;

    [System.Serializable]
    public class Armour
    {        
        public float BlastProtection;
        public float ProjectileProtection;
        public float DepthProtection;
        [Space]
        public float TotalProtection;
    }
}
