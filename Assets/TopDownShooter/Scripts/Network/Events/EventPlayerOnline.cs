using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public struct EventPlayerNetworkStateChange
    {
        public PlayerNetworkState PlayerNetworkState;

        public EventPlayerNetworkStateChange(PlayerNetworkState networkState)
        {
            PlayerNetworkState = networkState;
        }

    }
}