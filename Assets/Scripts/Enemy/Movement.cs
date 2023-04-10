using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] public Rigidbody Player;

        void Update()
        {
            MoveTo();
        }

        public void MoveTo()
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = Player.position;
        }
    }
}