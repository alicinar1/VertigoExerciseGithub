using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "Top Down Shooter/AI/AI Movement Input Data")]
    public class InputMovementDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            float distance = Vector3.Distance(_aITransfrom.position, _currentTarget);

            if (distance > 3)
            {
                Vertical = 1;
            }
            else
            {
                Vertical = 0;
            }

            
            Vector3 direction = _currentTarget - _aITransfrom.position;

            var rotation = Quaternion.LookRotation(direction, Vector3.up).eulerAngles;

            if (rotation.y > 360)
            {
                rotation.y = 360 - rotation.y;
            }

            var rotationGap = Mathf.Abs(rotation.y - _aITransfrom.rotation.eulerAngles.y);

            if (Mathf.Abs(rotationGap) > 5)
            {
                float rotationClamped = Mathf.Clamp(rotationGap / 180, -1, 1);
                
                Horizontal = rotationClamped;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}
