using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.AI
{
    public class InputDataAI : InputData
    {
        protected Vector3 _currentTarget;
        protected Transform _aITransfrom;


        public void SelectTarget(Transform aITransform, Vector3 target)
        {
            _aITransfrom = aITransform;
            _currentTarget = target;
        }

        public override void ProcessInput()
        {
            base.ProcessInput();
        }
    }
}
