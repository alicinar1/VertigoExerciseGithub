using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "Top Down Shooter/AI/AI Rotation Input Data")]
    public class InputRotationDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            base.ProcessInput();
            //Vector3 direction = _currentTarget - _aITransfrom.position;

            //if (Mathf.Abs(direction.y - _aITransfrom.rotation.eulerAngles.y) > 1)
            //{
            //    Horizontal = 1;
            //}
            //else
            //{
            //    Horizontal = 0;
            //}            
        }
    }
}
