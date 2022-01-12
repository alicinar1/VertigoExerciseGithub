using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using UnityEngine;

namespace TopDownShooter.Stat
{
    public static class DamagableHelper
    {
        public static Dictionary<int, IDamagable> DamagableList = new Dictionary<int, IDamagable>();
        public static void InitializeDamagable(this IDamagable damagable)
        {
            DamagableList.Add(damagable.InstanceID, damagable);
        }

        public static void DestroyDamagable(this IDamagable damagable)
        {
            DamagableList.Remove(damagable.InstanceID);
        }
    }

    public interface IDamagable
    {
        int InstanceID { get; }
        void Damage(IDamage dmg);

    }
}