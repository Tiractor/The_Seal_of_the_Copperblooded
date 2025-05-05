using Core.Events;
using UnityEngine;


namespace Core.Mind.Player
{
    public class ButtonPressEvent : ComponentEvent
    {
        public KeyCode Button;
        public ButtonPressEvent(KeyCode button)
        {
            Button = button;
        }
    }

}
