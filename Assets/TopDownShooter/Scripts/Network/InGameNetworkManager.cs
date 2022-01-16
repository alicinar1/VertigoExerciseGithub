using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;

namespace TopDownShooter.Network
{
    public enum InGameNetworkState { NotReady, Ready}
    public class InGameNetworkManager : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;
        private InGameNetworkState _inGameNetworkState;

        private void Awake()
        {
            MessageBroker.Default.Receive<EventSceneLoaded>().Subscribe(OnSceneLoaded).AddTo(gameObject);
            MessageBroker.Default.Receive<EventPlayerShoot>().Subscribe(OnPlayerShoot).AddTo(gameObject);
            MessageBroker.Default.Receive<EventPlayerGiveDamage>().Subscribe(OnPlayerGetDamage).AddTo(gameObject);
        }

        private void OnPlayerGetDamage(EventPlayerGiveDamage obj)
        {
            if (obj.ShooterStat.IsLocalPlayer)
            {
                Damage(obj.Damage, obj.Stat.ID, obj.ShooterStat.ID);
            }
        }

        private void OnPlayerShoot(EventPlayerShoot obj)
        {
            if (obj.Stat.IsLocalPlayer)
            {
                Shoot(obj.Origin);
            }
        }

        private void OnSceneLoaded(EventSceneLoaded obj)
        {
            switch (obj.SceneName)
            {
                case "GameScene":
                    _inGameNetworkState = InGameNetworkState.Ready;
                    PhotonNetwork.isMessageQueueRunning = false;
                    InstantiateLocalPlayer();
                    break;
                default:
                    _inGameNetworkState = InGameNetworkState.NotReady;
                    break;
            }
        }
    
        public void InstantiateLocalPlayer()
        {
            int[] allocatedViewIdArray = new int[_localPlayerPrefab.PhotonViews.Length];
            for (int i = 0; i < allocatedViewIdArray.Length; i++)
            {
                allocatedViewIdArray[i] = PhotonNetwork.AllocateViewID();
            }
            photonView.RPC("RPC_InstantiateLocalPlayer", PhotonTargets.AllBufferedViaServer, allocatedViewIdArray);
            PhotonNetwork.isMessageQueueRunning = true;
        }


        [PunRPC]
        public void RPC_InstantiateLocalPlayer(int[] viewIDArray ,PhotonMessageInfo photonMessageInfo)
        {
            var instantiated = Instantiate(photonMessageInfo.sender.IsLocal ? _localPlayerPrefab : _remotePlayerPrefab);
            instantiated.SetOwnership(photonMessageInfo.sender, viewIDArray);
        }

        public void Shoot(Vector3 origin)
        {
            photonView.RPC("RPC_Shoot", PhotonTargets.Others);
        }

        [PunRPC]
        public void RPC_Shoot(Vector3 origin, PhotonMessageInfo photonMessageInfo)
        {
            MessageBroker.Default.Publish(new EventPlayerShoot(origin, ScriptableStatManager.Instance.Find(photonMessageInfo.sender.ID)));
        }

        public void Damage(float dmg, int recieverID, int shooterID)
        {
            photonView.RPC("RPC_Damage", PhotonTargets.Others, dmg, recieverID, shooterID);
        }

        [PunRPC]
        public void RPC_Damage(float damage, int reciever, int shooter)
        {
            var recieverStat = ScriptableStatManager.Instance.Find(reciever);
            var shooterStat = ScriptableStatManager.Instance.Find(shooter);
            recieverStat.Damage(damage, shooterStat);
        }
    }
}
