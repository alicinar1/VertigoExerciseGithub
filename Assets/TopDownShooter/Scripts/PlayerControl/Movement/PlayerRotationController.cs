using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerMovement
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] private AbstractInputData _inputData;
        [SerializeField] private Transform _tower;
        [SerializeField] private TowerRotationSettings _towerRotationSetting;
        [SerializeField] private TowerRotationController _towerRotationController;

        public void InitializeInput(AbstractInputData inputData)
        {
            _inputData = inputData;
        }

        private void Update()
        {
            _tower.Rotate(0, _inputData.Horizontal * _towerRotationSetting.towerRotationSpeed, 0, Space.Self);
        }
    }
}
