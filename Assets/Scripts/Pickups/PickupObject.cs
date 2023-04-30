using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class PickupObject : ScriptableObject
    {
        [SerializeField] string ItemName = "Item";
        [SerializeField] Sprite ItemImage;

        public string GetItemName() { return ItemName; }

        public Sprite GetItemImage()
        {
            return ItemImage;
        }
    }
}