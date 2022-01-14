using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        [SerializeField] private PhotonView[] _photonViewsOwnerShip;
        public void SetOwnership(PhotonPlayer photonPlayer)
        {
            for (int i = 0; i < _photonViewsOwnerShip.Length; i++)
            {
                _photonViewsOwnerShip[i].TransferOwnership(photonPlayer);
            }
        }
    }
}
