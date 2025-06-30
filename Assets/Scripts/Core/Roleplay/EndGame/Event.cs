using Core.Events;

namespace Core.Roleplay.End
{
    public class SwitchGameStateEvent : SimpleEvent
    {
        public GameState Result;
        public SwitchGameStateEvent(GameState res)
        {
            Result = res;
        }

    }
}