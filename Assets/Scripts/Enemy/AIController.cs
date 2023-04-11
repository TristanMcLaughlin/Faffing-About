using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class AIController : MonoBehaviour
    {
        private GameObject Player;
        private Fighter CombatBehaviour;

        void Start ()
        {
            Player = GameObject.FindWithTag("Player");
            CombatBehaviour = GetComponent<Fighter>();
        }

        void Update()
        {
            MoveTo();

            if (DistanceToPlayer() < (CombatBehaviour.GetRange() - 0.5f))
            {
                CombatBehaviour.AutoAttack();
            }
        }

        private void MoveTo()
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Player.transform.position;
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(Player.transform.position, transform.position);
        }
    }
}