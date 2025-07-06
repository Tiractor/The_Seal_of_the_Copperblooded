using Core.Events;
using Core.Mind.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Roleplay.End
{
    public class GoalSystem : ComponentSystem
    {
        SealComponent goal;
        float maxDistance = -1;
        public override void Initialize()
        {
            Subscribe<SealComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<SwitchGameStateEvent>(SwitchState);
        }
        private void SwitchState(SwitchGameStateEvent args)
        {
            Cursor.lockState = CursorLockMode.None;
            switch (args.Result)
            {
                case GameState.MainMenu: SceneManager.LoadScene("MainMenu"); return;
                case GameState.Lose: SceneManager.LoadScene("LoseScreen"); return;
                case GameState.Win: SceneManager.LoadScene("WinScreen"); return;
            }
        }
        private void OnComponentInit(SealComponent component, ComponentInitEvent args)
        {
            goal = component;
            if (PlayerSystem._player != null) maxDistance = Vector3.Distance(PlayerSystem._player.transform.position, goal.transform.position);
        }
        public override void TickUpdate()
        {
            if (goal == null) return;
            if (maxDistance == -1)
            {
                if(PlayerSystem._player != null) maxDistance = Vector3.Distance(PlayerSystem._player.transform.position, goal.transform.position);
            }
            else
            {
                float distance = Vector3.Distance(PlayerSystem._player.transform.position, goal.transform.position);
                goal.m_AudioSource.volume = Mathf.Clamp01(1f - (distance / maxDistance));
            }

        }
    }
}
