using Core.Events;
using Core.Roleplay;
using System.Collections.Generic;
using UnityEngine;
using Core.Mind.Player;

namespace Core.Mind.NPC
{
    public class AISystem : ComponentSystem
    {
        private HashSet<AIComponent> _NPC = new();
        private HashSet<PlayerComponent> _targets = new();
        public override void Initialize()
        {
            Subscribe<AIComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<PlayerComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<AIComponent, DeathEvent>(OnAIDeath);
            Subscribe<PlayerComponent, DeathEvent>(OnPlayerDeath);
        }

        public override void SecondUpdate()
        {
            //base.SecondUpdate();
            foreach (var NPC in _NPC)
            {
                if(NPC == null) _NPC.Remove(NPC);
                if (NPC.Target == null) 
                {
                    foreach (var player in _targets)
                    {
                        var dist = Vector3.Distance(NPC.transform.position, player.transform.position);
                        if (dist <= NPC.AgroRange || dist < NPC.TargetRange) NPC.Target = player;
                    } 
                }
                else
                {
                    NPC.TargetRange = Vector3.Distance(NPC.transform.position, NPC.Target.transform.position);
                    if(NPC.TargetRange < NPC.PrimaryAttack.Range) TriggerEvent(NPC.PrimaryAttack, new AttackEvent(NPC.Target));
                    else if (NPC.SecondaryAttack!= null && NPC.TargetRange < NPC.SecondaryAttack.Range) TriggerEvent(NPC.SecondaryAttack, new AttackEvent(NPC.Target));
                    else if (NPC.SecondaryAttack != null && NPC.TargetRange < NPC.TertiaryAttack.Range) TriggerEvent(NPC.TertiaryAttack, new AttackEvent(NPC.Target));
                    if (NPC.TargetRange > NPC.ChaseRange)
                    {
                        NPC.TargetRange = -1;
                        NPC.Target = null;
                    }
                    else
                    {
                        if (NPC.Target != null)
                            NPC.agent.SetDestination(NPC.Target.transform.position);
                    }
                }
            }
        }

        private void OnComponentInit(AIComponent component, ComponentInitEvent args)
        {
            _NPC.Add(component);
        }
        private void OnComponentInit(PlayerComponent component, ComponentInitEvent args)
        {
            _targets.Add(component);
        }
        void OnAIDeath(AIComponent component, DeathEvent args)
        {
            _NPC.Remove(component);
        }
        void OnPlayerDeath(PlayerComponent component, DeathEvent args)
        {
            _targets.Remove(component);
        }
    }
}
