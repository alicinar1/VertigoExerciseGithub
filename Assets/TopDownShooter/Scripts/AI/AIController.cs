using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private InputDataAI _aIMovementInput;
        [SerializeField] private InputDataAI _aIRotationInput;
        [SerializeField] private InputDataAI _towerRotationInput;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private TowerRotationController _towerRotationController;

        public Transform TARGET;
        public Transform towerTarget;

        private void Awake()
        {
            _aIMovementInput = Instantiate(_aIMovementInput);
            _aIRotationInput = Instantiate(_aIRotationInput);
            _towerRotationInput = Instantiate(_towerRotationInput);

            _playerMovementController.InitializeInput(_aIMovementInput);
            _towerRotationController.InitializeInput(_aIRotationInput);

        }

        private void Update()
        {

            _aIMovementInput.SelectTarget(transform, TARGET.position);
            _aIRotationInput.SelectTarget(transform, TARGET.position);
            _towerRotationInput.SelectTarget(_towerRotationController.Tower, towerTarget.position);

            _aIMovementInput.ProcessInput();
            _aIRotationInput.ProcessInput();
            _towerRotationInput.ProcessInput();

            if (_towerRotationInput.Horizontal < 2 && Vector3.Distance(TARGET.position, transform.position) < 5)
            {
                _playerInventory.ReactiveShootCommand.Execute();
            }

            //_playerInventory.ReactiveShootCommand.Execute();
        }
    }
}
