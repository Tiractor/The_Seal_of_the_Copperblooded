using Core.EntityStatuses;
using UnityEngine;

namespace Core.Mind.Player
{
    public class PlayerComponent : MindComponent
    {
        private  void Update()
        {
            foreach (var key in ButtonsBind.Binds)
            {
                if (Input.GetKeyDown(key.Key))
                {
                    if(GameManager.instance.Debugging) Logger.Tech($"Нажата клавиша: {key}");
                    ComponentSystem.TriggerEvent(this, key.Value);
                }
            }
        }
        [ContextMenu("Add Status for test")]
        public void AddBleed()
        {
            Statuses.Add(new Bleeded());
        }

    }
}
