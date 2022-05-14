using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModule : Module
{
    public Weapon WeaponData;

    public ParticleSystem MuzzleFlash;

    [System.Serializable]
    public class Weapon 
    {
        public float Damage;
        public float Range;
        public float Accuracy;
        public float ReloadSpeed;
        public float Shots;
    }
}
