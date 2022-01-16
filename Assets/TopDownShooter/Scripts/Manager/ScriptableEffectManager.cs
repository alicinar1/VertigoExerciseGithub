using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Manager/ScriptableEffectManager")]

    public class ScriptableEffectManager : AbstractScriptableManager<ScriptableEffectManager>
    {
        [SerializeField] private GameObject _playerShootEffect;
        public override void Initialize()
        {
            base.Initialize();
            MessageBroker.Default.Receive<EventPlayerShoot>().Subscribe(OnPlayerShoot).AddTo(_disposable);
            MessageBroker.Default.Receive<EventPlayerGiveDamage>().Subscribe(OnPlayerGetDamage).AddTo(_disposable);
        }

        private void OnPlayerShoot(EventPlayerShoot obj)
        {
            Instantiate(_playerShootEffect, obj.Origin, Quaternion.identity);
        }

        private void OnPlayerGetDamage(EventPlayerGiveDamage obj)
        {
            if (obj.Stat.IsLocalPlayer)
            {
                Debug.Log("Local Player Get Damage");
            }
        }
    }
}
