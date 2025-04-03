using Spine.Unity;
using Spine;
using System.Collections;
using UnityEngine;

namespace Project
{
    public class ProjectileAnimator : MonoBehaviour
    {
        [SerializeField] private ProjectileCollision _collision;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _explosionAnimation;

        private void Awake() =>
            _collision.Collided += PlayExplosionAnimation;

        private void OnDestroy() =>
            _collision.Collided -= PlayExplosionAnimation;

        private void PlayExplosionAnimation() =>
            StartCoroutine(SetExplosionAnimation());

        public IEnumerator SetExplosionAnimation()
        {
            TrackEntry trackEntry = _skeletonAnimation.AnimationState.SetAnimation(0, _explosionAnimation, false);

            yield return new WaitForSpineAnimationComplete(trackEntry);

            Destroy(gameObject);
        }
    }
}
