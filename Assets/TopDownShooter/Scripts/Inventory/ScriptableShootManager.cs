using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Inventory/ScriptableShootManager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public override void Initialize()
        {
            Debug.Log("Scriptable Shoot Manager Activated");
        }

        private void OnDestroy()
        {
            Debug.Log("Scriptable Shoot Manager Destroyed");
        }

        public void Shoot(Vector3 origin, Vector3 direction)
        {
            Debug.Log("!!!!!!!");
            RaycastHit hit;
            var physic = Physics.Raycast(origin, direction, out hit);
            if (physic)
            {
                Debug.Log(hit.collider.name);
            }
        }

    }
}
