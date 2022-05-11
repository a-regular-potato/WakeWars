using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineModule : Module
{
    public Engine EngineData;

    [System.Serializable]
    public class Engine
    {
        public float Speed;
        public float Power;
        [Space]
        public float CurrentFuel;
        public float MaxFuel;
    }
}
