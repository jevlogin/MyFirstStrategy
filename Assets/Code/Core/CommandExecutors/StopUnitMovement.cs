using Abstractions;
using System;
using UnityEngine;
using UnityEngine.AI;
using Void = Utils.AsyncUtils.Void;


namespace Model
{
    public sealed class StopUnitMovement : MonoBehaviour, IAwaitable<Void>
    {
        public event Action OnStop;
        [SerializeField] private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0.0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }

        public IAwaiter<Void> GetAwaiter()
        {
           return new StopAwaiter(this);
        }
    }
}