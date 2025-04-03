using System.Collections;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private Point _bodyCenterPoint;

        private IInput _input;
        private CharacterAnimator _animator;
        private CharacterAimHandler _aimHanlder;
        private ProjectileSpawner _projectileSpawner;

        private bool _canAiming;

        public void Initialize(IInput input, CharacterAnimator animator, CharacterAimHandler aimHandler, ProjectileSpawner projectileSpawner)
        {
            _input = input;
            _animator = animator;
            _aimHanlder = aimHandler;
            _projectileSpawner = projectileSpawner;
        }

        private void OnMouseDown() =>
            StartCoroutine(WaitAnimationBeforeAim());

        private void OnMouseDrag()
        {
            if (_canAiming == false)
                return;

            Vector2 direction = _bodyCenterPoint.Position - _input.WorldMousePosition;
            _aimHanlder.Aim(direction);
        }

        private void OnMouseUp()
        {
            _aimHanlder.Stop();
            _projectileSpawner.TrySpawn(_aimHanlder.StartVelocity, _aimHanlder.AimDirection, ProjectileType.Arrow);
            _animator.SetIdleAnimation();
            _canAiming = false;
        }

        private IEnumerator WaitAnimationBeforeAim()
        {
            yield return StartCoroutine(_animator.SetStartAttackAnimation());

            _canAiming = true;
        }
    }
}
