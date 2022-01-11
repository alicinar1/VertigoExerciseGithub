using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCanonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform _canonShootPoint;
        public void Shoot()
        {
            Debug.Log("falan filan");
            ScriptableShootManager.Instance.Shoot(_canonShootPoint.position, _canonShootPoint.forward);
            //ScriptableShootManager.Instance.Shoot(Vector3.zero, Vector3.forward);  
        }
    }
}
