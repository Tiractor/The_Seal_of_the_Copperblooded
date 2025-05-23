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
    public enum GameResult 
    {
        TrueWin,
        FalseWin,
        Lose
    }


    public class Endgame : SimpleEvent
    {
        public GameResult Result;
        public Endgame(GameResult result)
        {
            Result = result;
        }
    }

}
