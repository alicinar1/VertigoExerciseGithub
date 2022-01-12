using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerInput;

namespace TopDownShooter.PlayerControls
{
    public class LocalPlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private AbstractInputData _shootInput;

        private void Update()
        {
            if (_shootInput.Horizontal > 0)
            {
                _playerInventory.ReactiveShootCommand.Execute();
                //Debug.Log("Shoot Local Player Controller");
            }
        }

    }
}
