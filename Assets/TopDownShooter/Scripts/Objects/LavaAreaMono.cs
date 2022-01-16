using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Objects
{
    public class LavaAreaMono : MonoBehaviour, IDamage
    {
        [SerializeField] private float _damage;
        public float Damage{ get { return _damage; } }

        [Range(0.1f, 2)]
        [SerializeField] private float _armorPenentration = 3;
        public float ArmorPenentration { get { return _armorPenentration; } }

        [SerializeField] private float _timeBasedDamage = 1;
        public float TimeBasedDamage { get { return _timeBasedDamage; } }

        [SerializeField] private float _timeBasedDamageDuration;
        public float TimeBasedDamageDuration { get { return _timeBasedDamageDuration; } }

        public PlayerStat Stat { get { return null; } }

        private void OnTriggerEnter(Collider collider)
        {
            int colliderInstancaID = collider.GetInstanceID();
            if (DamagableHelper.DamagableList.ContainsKey(colliderInstancaID))
            {
                DamagableHelper.DamagableList[colliderInstancaID].Damage(this);
            }
        }
    }
}
