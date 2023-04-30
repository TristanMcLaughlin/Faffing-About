using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Combat
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] PickupObject PickupPrefab = null;
        [SerializeField] TMP_Text itemText;

        private GameObject Player;
        private static List<Pickup> pickups;

        private void Awake()
        {
            if (pickups == null)
            {
                pickups = new List<Pickup>();
            }

            pickups.Add(this);
        }

        void Start ()
        {
            itemText.enabled = false;
            itemText.text = PickupPrefab.name;
            Player = GameObject.FindWithTag("Player");
        }

        public static Pickup GetClosest(Vector3 Position)
        {
            Pickup closestPickup = null;

            foreach (Pickup pickup in pickups)
            {
                pickup.HideText();

                if (Vector3.Distance(Position, pickup.transform.position) <= 3f)
                {
                    closestPickup = pickup;
                }
            }

            if (closestPickup != null) {
                closestPickup.DisplayText();
            }

            return closestPickup;
        }

        private void DisplayPickUp()
        {
            RaycastHit hit;

            if(Physics.SphereCast(Player.transform.position, 2f, Player.transform.forward, out hit, 3f))
            {
                print(hit);
            }
        }

        public void DisplayText()
        {
            itemText.transform.rotation = Camera.main.transform.rotation;
            itemText.enabled = true;
        }
        public void HideText()
        {
            itemText.enabled = false;
        }

        public PickupObject getItem()
        {
            return this.PickupPrefab;
        }

        public void RemoveAndDestroy()
        {
            pickups.Remove(this);
            Destroy(this.gameObject);
        }
    }
}