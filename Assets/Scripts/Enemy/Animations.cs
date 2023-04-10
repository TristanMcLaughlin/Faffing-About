using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Animations : MonoBehaviour
    {
        [SerializeField] public string WalkAnimation;

        private UnityEngine.AI.NavMeshAgent navMeshAgent;

        void Start()
        {
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            WalkAnimations();
        }

        private void WalkAnimations()
        {
            float MaxSpeed = navMeshAgent.speed * 3f;
            float PlayerSpeed = Mathf.Clamp(navMeshAgent.velocity.sqrMagnitude, 0f, MaxSpeed);
            GetComponent<Animator>().SetFloat(WalkAnimation, PlayerSpeed / MaxSpeed);
        }
    }
}
