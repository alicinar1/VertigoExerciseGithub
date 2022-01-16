using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Network;
using TopDownShooter.Inventory;
using NetworkPlayer = TopDownShooter.Network.NetworkPlayer;
using UniRx;
using System;
using TopDownShooter.Stat;

namespace TopDownShooter
{
    public class PlayerController : MonoBehaviour, IPlayerStatHolder
    {
        [SerializeField] private DamagableObjectBase[] _damagebleObjectBases;
        [SerializeField] private NetworkPlayer _networkPlayer;
        [SerializeField] protected PlayerInventory _playerInventory;

        public PlayerStat PlayerStat { get; private set; }

        protected void Start()
        {
            _networkPlayer.RegisterStatHolder(_playerInventory);
            _networkPlayer.PlayerStat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);
            for (int i = 0; i < _damagebleObjectBases.Length; i++)
            {
                _networkPlayer.RegisterStatHolder(_damagebleObjectBases[i]);
            }
            _networkPlayer.RegisterStatHolder(this);
        }

        public void SetStat(PlayerStat stat)
        {
            PlayerStat = stat;
            stat.OnDeath.Subscribe(OnDeath).AddTo(gameObject);
        }

        private void OnDeath(Unit obj)
        {
            Debug.Log("death executed on : " + name);
            if (_networkPlayer.PlayerStat.IsLocalPlayer)
            {
                MatchMakingController.Instance.LeaveRoom();
            }
            else
            {
                Destroy(gameObject);
            }
        }


    }
}
