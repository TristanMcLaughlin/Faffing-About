using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class UI_Inventory : MonoBehaviour
    {
        private Inventory inventory;
        private Transform ItemSlotContainer;
        private Transform ItemSlotTemplate;

        // Start is called before the first frame update
        private void Awake()
        {
            ItemSlotContainer = transform.Find("ItemSlotContainer");
            ItemSlotTemplate = ItemSlotContainer.Find("ItemSlotTemplate");
        }

        public void SetInventory (Inventory inventory)
        {
            this.inventory = inventory;
        }

        public void RefreshInventoryItems()
        {
            int x = 0;
            int y = 0;
            float itemSlotCellSize = 45f;

            foreach(InventoryItem Item in inventory.GetItemList())
            {
                RectTransform itemSlotTransform = Instantiate(ItemSlotTemplate, ItemSlotContainer).GetComponent<RectTransform>();
                itemSlotTransform.gameObject.SetActive(true);
                itemSlotTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotTransform.Find("image").GetComponent<Image>();
                image.sprite = Item.GetItemImage();

                x++;

                if (x > 4)
                {
                    x = 0;
                    y++;
                }
            }
        }
    }
}