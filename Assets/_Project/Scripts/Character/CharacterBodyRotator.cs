using Spine;
using Spine.Unity;
using UnityEngine;

namespace Project
{
    public class CharacterBodyRotator : MonoBehaviour
    {
        [SerializeField, SpineBone] private string _rotationBoneName;
        [SerializeField, Range(4.0f, 16.0f)] private float _rotationSmoothness;

        private Skeleton _characterSkeleton;
        private Bone _bodyRotationBone;

        public void Initialize(Skeleton characterSkeleton)
        {
            _characterSkeleton = characterSkeleton;
            _bodyRotationBone = _characterSkeleton.FindBone(_rotationBoneName);
        }

        public void RotateAlongDirection(Vector2 direction)
        {
            float degreeAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float blendTime = 1 - Mathf.Exp(-1 * _rotationSmoothness * Time.deltaTime);

            _bodyRotationBone.Rotation = Mathf.LerpAngle(_bodyRotationBone.Rotation, degreeAngle, blendTime);
            _characterSkeleton.UpdateWorldTransform();
        }
    }
}
