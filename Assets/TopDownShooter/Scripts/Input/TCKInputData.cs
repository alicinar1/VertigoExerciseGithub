using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Input/TCK Player Input Data")]
    public class TCKInputData : AbstractInputData
    {
        public string axisName;
        public bool isAction;
        public override void ProcessInput()
        {
            if (isAction)
            {
                if (TCKInput.GetAction(axisName, EActionEvent.Down))
                {
                    Horizontal = 1;
                }
                else if(TCKInput.GetAction(axisName, EActionEvent.Up))
                {
                    Horizontal = 0;
                }
            }
            else
            {
                Vector2 move = TCKInput.GetAxis(axisName);
                Horizontal = move.x;
                Vertical = move.y;
            }
        }
    }
}
