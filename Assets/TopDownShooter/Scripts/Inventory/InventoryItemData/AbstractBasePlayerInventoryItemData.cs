using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


namespace TopDownShooter.Inventory
{

    public abstract class AbstractBasePlayerInventoryItemData : ScriptableObject
    {
        private PlayerInventory _playerInventory;
        protected CompositeDisposable _compositeDisposable;
        public virtual void Initialize(PlayerInventory targetPlayerInventory)
        {
            _playerInventory = targetPlayerInventory;
            _compositeDisposable = new CompositeDisposable();
        }

        public virtual void Destroy()
        {
            _compositeDisposable.Dispose();
            Destroy(this);
        }
    }
}
