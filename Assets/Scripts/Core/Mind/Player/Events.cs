using Core.Events;
using UnityEngine;


namespace Core.Mind.Player
{
    public class ButtonPressEvent : EntityEvent
    {
        public KeyCode Button;
        public ButtonPressEvent(KeyCode button)
        {
            Button = button;
        }
    }

}
