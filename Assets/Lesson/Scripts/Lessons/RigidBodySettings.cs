using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons
{
    [CreateAssetMenu(fileName = "RigidBodySettings", menuName = "Lessons/Lesson1/Control RigidBodySettings")]
    public class RigidBodySettings : ScriptableObject
    {
        [SerializeField] private Vector3 _jumpForce;
        public Vector3 JumpForce { get { return _jumpForce; } }
    }
}
