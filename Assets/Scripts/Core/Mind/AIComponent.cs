using UnityEngine;
using UnityEngine.AI;

namespace Core.Mind
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIComponent : MindComponent
    {
        [HideInInspector] public NavMeshAgent agent;
        public float AttackRange = 3;
        public float AgroRange = 10;
        public float ChaseRange = 20;
        public float TargetRange = -1;
#nullable enable
        public PlayerComponent? Target;
#nullable disable
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }
}
