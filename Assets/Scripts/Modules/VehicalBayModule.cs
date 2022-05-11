using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicalBayModule : Module
{
    public VehicalBay VehicalBayData;
    [System.Serializable]
    public class VehicalBay
    {
        public float CapacityLeft;
        public float TotalCapacity;
        [Space]
        public float LaunchSpeed;
    }
}
