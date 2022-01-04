using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Player/Tower Rotation Settings")]
    public class TowerRotationSettings : ScriptableObject
    {
        public float towerRotationSpeed = 1;
    }
}
