using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public enum InventoryDataType { Cannon, Body}
    public abstract class AbstractPlayerInventoryItemData<T> : AbstractBasePlayerInventoryItemData where T: AbstractPlayerInventoryItemMono
    {
        [SerializeField] protected string _itemID;
        [SerializeField] protected InventoryDataType _inventoryDataType;
        [SerializeField] protected T _prefab;
        

        protected T InstantiateAndInitializePrefab(Transform parent)
        {
            return Instantiate(_prefab, parent);
        }
    }
}
