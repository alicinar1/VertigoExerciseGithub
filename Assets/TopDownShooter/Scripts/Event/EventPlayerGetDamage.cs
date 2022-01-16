using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter
{
    public struct EventPlayerGiveDamage
    {
        public float Damage;
        public PlayerStat Stat;
        public PlayerStat ShooterStat;

        public EventPlayerGiveDamage(float damage, PlayerStat stat, PlayerStat shooterStat)
        {
            Damage = damage;
            Stat = stat;
            ShooterStat = shooterStat;
        }
    }
}
