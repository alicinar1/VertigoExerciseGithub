using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons
{
    public class ControlRigidBody : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private RigidBodySettings _settings;

        private void Update()
        {
            bool spaveKeyDown = Input.GetKeyDown(KeyCode.Space);

            if (spaveKeyDown)
            {
                _rigidbody.AddForce(_settings.JumpForce, ForceMode.Impulse);
            }
        }
    }
}
