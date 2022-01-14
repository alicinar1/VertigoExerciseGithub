using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Network;
using System;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Manager/ScriptableSceneManager")]
    public class ScriptableSceneManager : AbstractScriptableManager<ScriptableSceneManager>
    {
        [SerializeField] private string _menuScene;
        [SerializeField] private string _gameScene;
        public override void Initialize()
        {
            base.Initialize();
            SceneManager.LoadScene(_menuScene);
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(_disposable);
        }


        public override void Destroy()
        {
            base.Destroy();
        }

        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            switch (obj.PlayerNetworkState)
            {
                case PlayerNetworkState.Offline:
                    break;
                case PlayerNetworkState.Connecting:
                    break;
                case PlayerNetworkState.Connected:
                    break;
                case PlayerNetworkState.JoiningRoom:
                    break;
                case PlayerNetworkState.InRoom:
                    PhotonNetwork.isMessageQueueRunning = false;
                    SceneManager.LoadScene(_gameScene);
                    break;
                default:
                    break;
            }
        }
    }

}
