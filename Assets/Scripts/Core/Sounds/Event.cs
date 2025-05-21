using Core.Events;
using UnityEngine;

namespace Core.Sounds
{
    public class NewSoundEvent : SimpleEvent
    {
        public SubtitleData Data;
        public NewSoundEvent(SubtitleData data, GameObject where)
        {
            this.Data = data;
            Data.Source = where;
        }
    }
}
