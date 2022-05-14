using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarModule : Module
{
    public Radar RadarData;

    [System.Serializable]
    public class Radar
    {
        public float Range;
        public float Accuracy;
        [Space]
        public Type type;

        public enum Type
        {
            SWAY,
            PULSE,
        }
        [Space]
        public float ResetSpeed;
    }
}
