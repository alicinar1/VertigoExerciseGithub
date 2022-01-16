using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerControls;
using TopDownShooter.PlayerInput;
using UnityEngine;
using UniRx;

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

        public List<AITarget> targetList;
        private int _currentTargetIndex;
        public Transform TARGET;
        public Transform towerTarget;
        private Vector3 _targetMovementPosition;
        private CompositeDisposable _targetDispose;

        private void Start()
        {
            _aIMovementInput = Instantiate(_aIMovementInput);
            _aIRotationInput = Instantiate(_aIRotationInput);
            _towerRotationInput = Instantiate(_towerRotationInput);

            _playerMovementController.InitializeInput(_aIMovementInput);
            _towerRotationController.InitializeInput(_aIRotationInput);

            UpdateTarget();

        }

        public void UpdateTarget()
        {
            var position = transform.position;
            _targetMovementPosition = position + ((targetList[0].transform.position - position).normalized * (Vector3.Distance(targetList[0].transform.position, position) - 10));

            _aIMovementInput.SelectTarget(transform, _targetMovementPosition);
            _aIRotationInput.SelectTarget(transform, _targetMovementPosition);
            _towerRotationInput.SelectTarget(_towerRotationController.Tower, targetList[0].transform.position);

            _targetDispose = new CompositeDisposable();
            targetList[0].PlayerStat.OnDeath.Subscribe(OnTargetDeath).AddTo(_targetDispose);
        }

        public void OnTargetDeath(Unit obj) 
        {
            _targetDispose.Dispose();
            targetList.RemoveAt(0);
            if (targetList.Count > 0)
            {
                UpdateTarget();
            }
            else
            {
                this.enabled = false;
            }
        }

        private void Update()
        {
            _aIMovementInput.ProcessInput();
            _aIRotationInput.ProcessInput();
            _towerRotationInput.ProcessInput();

            if (_towerRotationInput.Horizontal < 2 && Vector3.Distance(_targetMovementPosition, transform.position) < 5)
            {
                _playerInventory.ReactiveShootCommand.Execute();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_targetMovementPosition, 5);
        }
    }
}
