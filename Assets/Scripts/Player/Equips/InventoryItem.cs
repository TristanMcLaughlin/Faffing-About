using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    [Serializable]
    public class InventoryItem
    {
        public PickupObject invEntry;

        // Constructor
        public InventoryItem(PickupObject invEntry)
        {
            this.invEntry = invEntry;
        }

        public Sprite GetItemImage()
        {
            return invEntry.GetItemImage();
        }
    }
}
