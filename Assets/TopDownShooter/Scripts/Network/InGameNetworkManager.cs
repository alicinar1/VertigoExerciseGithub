using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class InGameNetworkManager : Photon.PunBehaviour
    {
        [SerializeField] private NetworkPlayer _localPlayerPrefab;
        [SerializeField] private NetworkPlayer _remotePlayerPrefab;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(10);
            InstantiateLocalPlayer();
        }
        public void InstantiateLocalPlayer()
        {
            var Instantiated = Instantiate(_localPlayerPrefab);
            Instantiated.SetOwnership(PhotonNetwork.player);
            photonView.RPC("RPC_InstantiateLocalPlayer", PhotonTargets.OthersBuffered);
            PhotonNetwork.isMessageQueueRunning = true;
        }


        [PunRPC]
        public void RPC_InstantiateLocalPlayer(PhotonMessageInfo photonMessageInfo)
        {
            Debug.Log("INSTANTÝATE LOCAL PLAYER");
            var Instantiated = Instantiate(_remotePlayerPrefab);
            Instantiated.SetOwnership(photonMessageInfo.sender);
        }
    }
}
