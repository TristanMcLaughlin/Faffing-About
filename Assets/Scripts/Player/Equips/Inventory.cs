using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] List<InventoryItem> inventoryItems = new List<InventoryItem>();
        [SerializeField] private UI_Inventory uiInventory;

        private void Awake()
        {
            uiInventory.SetInventory(this);
        }

        void Update()
        {
            Pickup pickup = Pickup.GetClosest(transform.position);
            if (pickup != null)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    inventoryItems.Add(new InventoryItem(pickup.getItem()));
                    uiInventory.RefreshInventoryItems();
                    pickup.RemoveAndDestroy();
                }
            }
        }

        public List<InventoryItem> GetItemList()
        {
            return inventoryItems;
        }
    }
}