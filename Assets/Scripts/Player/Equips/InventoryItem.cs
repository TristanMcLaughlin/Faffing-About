using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    [Serializable]
    public class InventoryItem
    {
        public ScriptableObject invEntry;

        // Constructor
        public InventoryItem(ScriptableObject invEntry)
        {
            this.invEntry = invEntry;
        }
    }
}
