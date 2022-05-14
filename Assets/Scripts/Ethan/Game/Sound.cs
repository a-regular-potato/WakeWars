using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float Volume;
    [Range(0.1f, 3)]
    public float Pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}
