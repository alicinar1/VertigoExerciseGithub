using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public class PlayerStat : IDamagable
    {

        public int ID { get; set; }
        public bool IsLocalPlayer { get; set; }

        public int InstanceID { get; private set; } = -1;

        public ReactiveProperty<float> Health = new ReactiveProperty<float>(100);
        public ReactiveCommand OnDeath = new ReactiveCommand();
        public ReactiveProperty<float> Armor { get; set; }

        private bool _isDead = false;

        public PlayerStat(int id, bool isLocalPlayer)
        {
            ID = id;
            IsLocalPlayer = isLocalPlayer;
            ScriptableStatManager.Instance.RegisterStats(this);
        }

        public void Damage(IDamage dmg)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= dmg.Damage * dmg.ArmorPenentration;
            }
            else
            {
                Debug.Log("You Damaged me: " + dmg.Damage);
                Health.Value -= dmg.Damage;
                Health.Value += Armor.Value;
                CheckHealt();
            }
            MessageBroker.Default.Publish(new EventPlayerGiveDamage(dmg.Damage, this, dmg.Stat));
        }

        public void Damage(float dmg, PlayerStat shooter)
        {
            if (Armor.Value > 0)
            {
                Armor.Value -= dmg * dmg;
            }
            else
            {
                Debug.Log("You Damaged me: " + dmg);
                Health.Value -= dmg;
                Health.Value += Armor.Value;
                CheckHealt();
            }
            MessageBroker.Default.Publish(new EventPlayerGiveDamage(dmg, this, shooter));
        }

        private void CheckHealt()
        {
            if (_isDead)
            {
                return;
            }

            if (Health.Value <= 0)
            {
                _isDead = true;
                OnDeath.Execute();
            }
        }
    }
}
