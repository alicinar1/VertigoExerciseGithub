using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public interface IDamage
    {
        float Damage { get; }
        float ArmorPenentration { get; }
        float TimeBasedDamage { get; }
        float TimeBasedDamageDuration { get; }
    }
}
