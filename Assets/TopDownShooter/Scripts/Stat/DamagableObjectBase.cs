using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Inventory;

namespace TopDownShooter.Stat
{
    public class DamagableObjectBase : MonoBehaviour, IDamagable
    {
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }
        public float Health = 100;
        public float Armor = 100;
        private bool _isDead = false;
        public ReactiveCommand OnDeath = new ReactiveCommand();

        private Vector3 _defaultScale;

        protected virtual void Awake()
        {
            InstanceID = _collider.GetInstanceID();
            this.InitializeDamagable();
            _defaultScale = transform.lossyScale;
        }

        protected virtual void Destroy()
        {
            this.DestroyDamagable();
        }

        public virtual void Damage(IDamage dmg)
        {
            if (dmg.TimeBasedDamage > 0)
            {
                StartCoroutine(TimeBasedDamage(dmg.TimeBasedDamage, dmg.TimeBasedDamageDuration));
            }
            if (Armor > 0)
            {
                Armor -= dmg.Damage * dmg.ArmorPenentration;
            }
            else
            {
                Debug.Log("You Damaged me: " + dmg.Damage);
                Health -= dmg.Damage;
                Health += Armor;
                CheckHealt();
            }            
        }


        IEnumerator TimeBasedDamage(float damage, float totalDuration)
        {
            while (totalDuration > 0)
            {
                yield return new WaitForSeconds(1);
                totalDuration -= 1;
                Health -= damage;
                CheckHealt();
            }
        }

        private void CheckHealt()
        {
            if (_isDead)
            {
                return;
            }

            if (Health <= 0)
            {
                StopAllCoroutines();
                _isDead = true;
                OnDeath.Execute();
                Destroy(gameObject);
            }
        }
    }
}
