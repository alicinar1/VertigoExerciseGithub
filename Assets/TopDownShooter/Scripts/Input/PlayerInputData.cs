using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Input/Player Input Data")]
    public class PlayerInputData : AbstractInputData
    {

        private float _increaseAmount = 0.015f;

        [Header("Axis base control")]
        [SerializeField] private bool _axisActieve;
        [SerializeField] private string AxisNameHorizontal;
        [SerializeField] private string AxisNameVertical;

        [Header("Key base control")]
        [SerializeField] private bool _keyBaseHorizontalActieve;
        [SerializeField] private KeyCode PositiveHorizontalKeyCode;
        [SerializeField] private KeyCode NegativeHorizontalKeyCode;
        [SerializeField] private bool _keyBaseVerticalActieve;
        [SerializeField] private KeyCode PositiveVerticalKeyCode;
        [SerializeField] private KeyCode NegativeVerticalKeyCode;

        public override void ProcessInput()
        {
            if (_axisActieve)
            {
                Horizontal = Input.GetAxis(AxisNameHorizontal);
                Vertical = Input.GetAxis(AxisNameVertical);
            }
            else
            {
                if (_keyBaseHorizontalActieve)
                {
                    KeyBaseAxisControl(ref Horizontal, PositiveHorizontalKeyCode, NegativeHorizontalKeyCode);
                }
                if (_keyBaseVerticalActieve)
                {
                    KeyBaseAxisControl(ref Vertical, PositiveVerticalKeyCode, NegativeVerticalKeyCode);
                }
            }
        }

        private void KeyBaseAxisControl(ref float value, KeyCode positive, KeyCode negative)
        {
            bool isPositiveKeyActieve = Input.GetKey(positive);
            bool isNegativeKeyActieve = Input.GetKey(negative);
            
            if (isPositiveKeyActieve)
            {
                value += _increaseAmount;
            }
            else if (isNegativeKeyActieve)
            {
                value -= _increaseAmount;
            }
            else
            {
                value = 0;
            }

            value = Mathf.Clamp(value, -1, 1);
        }
    }
}
