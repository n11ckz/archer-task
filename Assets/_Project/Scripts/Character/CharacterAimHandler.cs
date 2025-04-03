using UnityEngine;

namespace Project
{
    public class CharacterAimHandler : MonoBehaviour
    {
        [SerializeField, Min(3.0f)] private float _maxPullRadius;
        [SerializeField, Min(0.1f)] private float _forceMultiplier;
        [SerializeField] private Vector2 _aimAngleRange;

        public Vector2 AimDirection { get; private set; }
        public Vector2 StartVelocity => AimDirection * _forceMultiplier;

        private CharacterBodyRotator _bodyRotator;
        private TrajectoryRenderer _trajectoryRenderer;

        public void Initialize(CharacterBodyRotator bodyRotator, TrajectoryRenderer trajectoryRenderer)
        {
            _bodyRotator = bodyRotator;
            _trajectoryRenderer = trajectoryRenderer;
        }

        public void Aim(Vector2 direction)
        {
            float degreeAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (degreeAngle >= _aimAngleRange.x && degreeAngle <= _aimAngleRange.y)
                AimDirection = Vector2.ClampMagnitude(direction, _maxPullRadius);

            _bodyRotator.RotateAlongDirection(AimDirection);
            _trajectoryRenderer.Render(StartVelocity);
        }

        public void Stop() =>
            _trajectoryRenderer.Clear();
    }
}
