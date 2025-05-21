using System;
using UnityEngine;

namespace Core.Sounds
{
    [CreateAssetMenu(fileName = "NewSound", menuName = "Core/Sound")]
    [Serializable]
    public class SubtitleData : ScriptableObject
    {
        public string Text = "";
        public AudioClip Sound;
        [HideInInspector]public GameObject Source;
    }
}
