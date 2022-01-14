using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using TMPro;
using UnityEngine.UI;

namespace TopDownShooter.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentState;
        [SerializeField] private Button[] _networkButtons;

        private void Awake()
        {
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(gameObject);
            _currentState.text = "Falan Filan";
        }

        private void OnPlayerNetworkState(EventPlayerNetworkStateChange networkStateChange)
        {
            _currentState.text = "Connection state: " + networkStateChange.PlayerNetworkState;

            for (int i = 0; i < _networkButtons.Length; i++)
            {
                _networkButtons[i].interactable = networkStateChange.PlayerNetworkState == PlayerNetworkState.Connected;
            }
        }

        public void _CreateRoomClick()
        {
            MatchMakingController.Instance.CreateRoom();
        }

        public void _JoinRandomRoomClick()
        {
            MatchMakingController.Instance.JoinRandomRoom();
        }

        public void _SettingsClick()
        {
            Debug.LogError("Not ready yet.");
        }
    }
}