using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Inventory;

namespace TopDownShooter.Stat
{
    public class DamagableObjectBase : MonoBehaviour, IDamagable, IPlayerStatHolder
    {
        [SerializeField] private Collider _collider;
        public int InstanceID { get; private set; }

        public PlayerStat PlayerStat { get; private set; }


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
                StartCoroutine(TimeBasedDamage(dmg.TimeBasedDamage, dmg.TimeBasedDamageDuration, dmg.Stat));
            }
            else
            {
                PlayerStat.Damage(dmg);
            }
           
        }

        IEnumerator TimeBasedDamage(float damage, float totalDuration, PlayerStat playerStat)
        {
            while (totalDuration > 0)
            {
                yield return new WaitForSeconds(1);
                totalDuration -= 1;
                PlayerStat.Damage(damage, playerStat);
            }
        }

        public void SetStat(PlayerStat stat)
        {
            PlayerStat = stat;
        }
    }
}
