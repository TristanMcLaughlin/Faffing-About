using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Health))]
    public class AIController : MonoBehaviour
    {
        [SerializeField] float ChaseDistance = 5f;
        [SerializeField] float SuspicionTime = 5f;

        private GameObject Player;
        private Fighter CombatBehaviour;
        private Health AiHealth;

        Vector3 GuardLocation;
        float TimeSinceLastSawPlayer = 0f;

        void Start ()
        {
            Player = GameObject.FindWithTag("Player");
            CombatBehaviour = GetComponent<Fighter>();
            AiHealth = GetComponent<Health>();
            GuardLocation = transform.position;
        }

        void Update()
        {
            if (AiHealth.IsDead())
            {
                return;
            }

            if (DistanceToPlayer() < ChaseDistance)
            {
                TimeSinceLastSawPlayer = 0f;
                MoveTo(Player.transform.position);
            } 
            else if(TimeSinceLastSawPlayer < SuspicionTime) 
            {
            }
            else if (DistanceToPlayer() > ChaseDistance && DistanceToPlayer() > CombatBehaviour.GetRange())
            {
                MoveTo(GuardLocation);
            }

            if (DistanceToPlayer() < (CombatBehaviour.GetRange() - 0.5f))
            {
                CombatBehaviour.AutoAttack();
            }

            TimeSinceLastSawPlayer += Time.deltaTime;
        }

        private void MoveTo(Vector3 position)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = position;
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(Player.transform.position, transform.position);
        }

        // Called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, ChaseDistance);
        }
    }
}