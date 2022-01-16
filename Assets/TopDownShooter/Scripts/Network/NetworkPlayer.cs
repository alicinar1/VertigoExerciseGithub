using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        private bool isInitialized = false;
        public PlayerStat PlayerStat { get; private set; }
        [SerializeField] private PhotonView[] _photonViewsOwnerShip;
        private List<IPlayerStatHolder> _playerStatHolderList = new List<IPlayerStatHolder>();
        public PhotonView[] PhotonViews { get { return _photonViewsOwnerShip; } }
        public void SetOwnership(PhotonPlayer photonPlayer, int[] allocatedViewIDArray)
        {
            Debug.Log("Set ownership for " + photonPlayer.name);
            for (int i = 0; i < _photonViewsOwnerShip.Length; i++)
            {
                _photonViewsOwnerShip[i].TransferOwnership(photonPlayer);
                _photonViewsOwnerShip[i].viewID = allocatedViewIDArray[i];
            }
            PlayerStat = new PlayerStat(photonPlayer.ID, photonPlayer.IsLocal);
            for (int i = 0; i < _playerStatHolderList.Count; i++)
            {
                _playerStatHolderList[i].SetStat(PlayerStat);
            }
            isInitialized = true;
        }

        public void RegisterStatHolder(IPlayerStatHolder playerStatHolder)
        {
            _playerStatHolderList.Add(playerStatHolder);
            if (isInitialized)
            {
                playerStatHolder.SetStat(PlayerStat);
            }
        }
        public void UnregisterStatHolder(IPlayerStatHolder playerStatHolder)
        {
            _playerStatHolderList.Remove(playerStatHolder);
        }
    }
}
