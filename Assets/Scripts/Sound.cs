using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sounds", menuName = "ScriptableObjects/SoundScriptableObject", order = 1)]
public class Sound : ScriptableObject
{
    public EnumsManager.Sound type;
    public AudioClip clip;
}
