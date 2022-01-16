using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace TopDownShooter.Network
{
    public enum PlayerNetworkState { None, Offline, Connecting, Connected, JoiningRoom, LeavingRoom, InRoom }
    public class MatchMakingController : Photon.PunBehaviour
    {
        private PlayerNetworkState _currentNetworkSatate = PlayerNetworkState.None;

        public PlayerNetworkState CurrentNetworkState
        {
            get { return _currentNetworkSatate; }
            set
            {
                bool sendEvent = false;

                if (value != _currentNetworkSatate)
                {
                    sendEvent = true;
                }

                _currentNetworkSatate = value;

                if (sendEvent)
                {
                    MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(_currentNetworkSatate));
                }
            }
        }

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
            PhotonNetwork.CacheSendMonoMessageTargets(typeof(MatchMakingController));
        }

        private IEnumerator Start()
        {
            CurrentNetworkState = PlayerNetworkState.Offline;
            yield return new WaitForEndOfFrame();
            CurrentNetworkState = PlayerNetworkState.Connecting;
            PhotonNetwork.ConnectUsingSettings(_NetworkVersion);
        }

        public void CreateRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            CurrentNetworkState = PlayerNetworkState.InRoom;
            PhotonNetwork.isMessageQueueRunning = false;
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            CurrentNetworkState = PlayerNetworkState.Connected;
        }

        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            CurrentNetworkState = PlayerNetworkState.Offline;
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            CurrentNetworkState = PlayerNetworkState.Connected;
            Debug.Log("ON CONNECTED TO MASTER");
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("ON JOINED LOBBY");
        }

        public void LeaveRoom()
        {
            CurrentNetworkState = PlayerNetworkState.LeavingRoom;
            PhotonNetwork.LeaveRoom();
        }
    }
}