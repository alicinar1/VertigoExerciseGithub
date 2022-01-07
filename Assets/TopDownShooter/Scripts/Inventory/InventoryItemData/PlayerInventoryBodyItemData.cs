using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Inventory/Player Inventory Body")]
    public class PlayerInventoryBodyItemData : AbstractPlayerInventoryItemData<PlayerInventoryBodyItemMono>
    {
        public override void CreateIntoInventory(PlayerInventory targetPlayerInventory)
        {
            var instantiate = InstantiateAndInitializePrefab(targetPlayerInventory.parent);
            Debug.Log("Body Item Data");
        }
    }
}
