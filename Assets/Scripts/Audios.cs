using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu(fileName = "New Audios", menuName = "Audios")]
public class Audios : ScriptableObject
{
    public List<AudioClip> audios;
}
