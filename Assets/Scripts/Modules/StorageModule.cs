using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageModule : Module
{
    public Storage StorageData;

    [System.Serializable]
    public class Storage
    {
        public float StorageLeft;
        public float StorageCapcity;
    }
}
