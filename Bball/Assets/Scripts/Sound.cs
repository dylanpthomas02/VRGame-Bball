using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
    [Range(0f, 1f)]
    public float spatialBlend = 1.0f;
}
