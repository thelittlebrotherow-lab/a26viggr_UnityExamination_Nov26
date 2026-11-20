using UnityEngine;
using System;

[Serializable]

public struct SoundList
{
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}