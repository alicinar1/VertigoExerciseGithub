using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;

namespace TopDownShooter.PlayerInput
{
    public class LocalPlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private InputData _shootInput;

        private void Update()
        {
            if (_shootInput.Horizontal > 0)
            {
                _playerInventory.ReactiveShootCommand.Execute();
                Debug.Log("Shoot Local Player Controller");
            }
        }

    }
}
