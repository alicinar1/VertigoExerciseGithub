using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{
    public enum PlayerNetworkState { Offline, Connecting, Connected, JoiningRoom, InRoom }
    public class MatchMakingController : Photon.PunBehaviour
    {
        private static volatile MatchMakingController instance = null;
        public static MatchMakingController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType(typeof(MatchMakingController)) as MatchMakingController;
                }

                return instance;
            } 
        }

        private float _delayToConnect = 1;
        public const string _NetworkVersion = "v1.0";
        private void Awake()
        {
            int i = Instance.GetHashCode();
            Debug.Log(i);
        }

        private IEnumerator Start()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
            yield return new WaitForSeconds(_delayToConnect);
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));
            PhotonNetwork.ConnectUsingSettings(_NetworkVersion);
        }

        public void CreateRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.InRoom));
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
            Debug.Log("ON CONNECTED TO MASTER");
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("ON JOINED LOBBY");
        }
    }
}