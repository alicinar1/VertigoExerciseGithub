using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerControls
{
    public class TowerRotationController : MonoBehaviour
    {
        [SerializeField] private InputData _rotationInputData;
        [SerializeField] private Transform _tower;
        [SerializeField] private TowerRotationSettings _settings;

        private void Update()
        {
            _tower.Rotate(0, _rotationInputData.Horizontal * _settings.towerRotationSpeed, 0, Space.Self);
        }
    }
}
