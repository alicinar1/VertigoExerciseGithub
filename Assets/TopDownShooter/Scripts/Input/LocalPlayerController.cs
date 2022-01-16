using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TopDownShooter.Inventory;
using TopDownShooter.PlayerInput;
using TopDownShooter.Stat;

namespace TopDownShooter.PlayerControls
{
    public class LocalPlayerController : PlayerController
    {
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
