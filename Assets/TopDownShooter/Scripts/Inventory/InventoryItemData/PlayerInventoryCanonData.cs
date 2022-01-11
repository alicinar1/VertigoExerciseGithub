using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Inventory/Player Inventory Canon")]
    public class PlayerInventoryCanonData : AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>
    {
        [SerializeField] private float _damage;

        public float Damage
        {
            get { return _damage; }
        }

        [SerializeField] private float _rpm = 1f;

        public float Rpm
        {
            get { return _rpm = 1f; }
        }

        private float _lastShootTime;


        public override void Initialize(PlayerInventory targetPlayerInventory)
        {
            base.Initialize(targetPlayerInventory);
            InstantiateAndInitializePrefab(targetPlayerInventory.CannonParent);
            targetPlayerInventory.ReactiveShootCommand.Subscribe(OnReactiveShootCommand).AddTo(_compositeDisposable);
            Debug.Log("Canon Item Data");
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void OnReactiveShootCommand(Unit obj)
        {
            Debug.Log("Reactive command Shoot");
            Shoot();
        }

        public void Shoot()
        {
            //_instantiated.Shoot();
            //_lastShootTime = Time.time;
            //Debug.Log("Shoot");

            if (Time.time - _lastShootTime > _rpm)
            {
                _instantiated.Shoot();
                _lastShootTime = Time.time;
                Debug.Log("Shoot!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
            else
            {
                Debug.Log("You can't shoot now");
                Debug.Log(Time.time - _lastShootTime);
                Debug.Log(_rpm);
            }
        }
    }
}
