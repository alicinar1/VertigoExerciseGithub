using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Camera
{
    [CreateAssetMenu(menuName = "Top Down Shooter/Camera/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        [Header("Rotation")]
        [SerializeField] private float _rotationLerpSpeed;

        public float RotationLerpSpeed
        {
            get { return _rotationLerpSpeed; }
        }

        [Header("Position")]
        [SerializeField] private Vector3 offset;

        public Vector3 Offset
        {
            get { return offset; }
        }

        [SerializeField] private float _positionLerpSpeed;

        public float PositionLerpSpeed
        {
            get { return _positionLerpSpeed; }
        }



    }
}
