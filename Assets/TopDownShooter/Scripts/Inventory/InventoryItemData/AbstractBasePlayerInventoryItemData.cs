using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDownShooter.Inventory
{

    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        public abstract void CreateIntoInventory(PlayerInventory targetPlayerInventory);

        public virtual void Destroy()
        {
            Destroy(this);
        }
    }
}
