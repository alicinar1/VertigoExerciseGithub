using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerMovement
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private Rigidbody _ridigBody;
        [SerializeField] private PlayerMovementSettings _playerMovementSettings;

        private void Update()
        {
            _ridigBody.MovePosition(_ridigBody.position + _ridigBody.transform.forward * _inputData.Vertical * _playerMovementSettings.VerticalSpeed);
            _ridigBody.MovePosition(_ridigBody.position + _ridigBody.transform.right * _inputData.Horizontal * _playerMovementSettings.HorizontalSpeed);
        }
    }
}
