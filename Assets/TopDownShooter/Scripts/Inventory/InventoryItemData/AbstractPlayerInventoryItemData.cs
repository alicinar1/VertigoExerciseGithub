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
        protected T _instantiated;
        

        protected T InstantiateAndInitializePrefab(Transform parent)
        {
            _instantiated = Instantiate(_prefab, parent);
            return _instantiated;
        }
    }
}
