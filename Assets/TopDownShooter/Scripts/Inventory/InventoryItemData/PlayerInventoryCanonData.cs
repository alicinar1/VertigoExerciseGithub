using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Inventory/Player Inventory Canon")]
    public class PlayerInventoryCanonData : AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>
    {
        [SerializeField] private float _damage;

        public float MyProperty
        {
            get { return _damage; }
        }

        public override void CreateIntoInventory(PlayerInventory targetPlayerInventory)
        {
            var instantiate = InstantiateAndInitializePrefab(targetPlayerInventory.parent);
            Debug.Log("Canon Item Data");
        }
    }
}
