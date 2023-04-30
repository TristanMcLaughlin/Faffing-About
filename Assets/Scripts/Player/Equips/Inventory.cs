using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] List<Pickup> pickups = new List<Pickup>();

        void Update()
        {
            Pickup pickup = Pickup.GetClosest(transform.position);
            if (pickup != null)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    print(pickup.name);
                }
            }
        }
    }
}