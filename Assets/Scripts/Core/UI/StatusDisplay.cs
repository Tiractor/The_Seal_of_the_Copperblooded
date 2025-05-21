using Core.EntityStatuses;
using Core.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class StatusDisplay : EventComponent
    {
        public TextMeshProUGUI text;
        [SerializeReference] public EntityStatus display = new Fired();
        public Image round;
        public Image icon;

        [ContextMenu("ForcedUpdate")]
        public void DisplayStatuses()
        {
            EventSystem.TriggerEvent(new SimpleComponentEvent(this));
        }
    }
}
