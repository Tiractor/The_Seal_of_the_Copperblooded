using Core.Events;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class StatDisplay : EventComponent
    {
        public Display what;
        public TextMeshProUGUI text;

        [ContextMenu("ForcedUpdate")]
        public void DisplayStatuses()
        {
            EventSystem.TriggerEvent(new SimpleComponentEvent(this));
        }
    }
}
