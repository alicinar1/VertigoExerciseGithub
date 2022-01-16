using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCanonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform _canonShootPoint;
        public void Shoot(IDamage dmg, PlayerStat stat)
        {
            Debug.Log("falan filan");
            ScriptableShootManager.Instance.Shoot(_canonShootPoint.position, _canonShootPoint.forward, dmg, stat);
            //ScriptableShootManager.Instance.Shoot(Vector3.zero, Vector3.forward);  
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_canonShootPoint.position, 0.15f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_canonShootPoint.position, _canonShootPoint.position + _canonShootPoint.forward * 20);
        }
    }
}
