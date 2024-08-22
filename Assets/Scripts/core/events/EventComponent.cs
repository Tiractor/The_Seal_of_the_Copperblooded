using UnityEngine;

namespace Core.Events
{
    /// <summary>
    ///     Base class for event-use objects
    /// </summary>
    public abstract class EventComponent : MonoBehaviour
    {
        private void Start()
        {
            ComponentSystem.TriggerEvent(this, new ComponentInitEvent(this));
        }
    }
}