using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;
using AnimationState = Spine.AnimationState;

namespace Project
{
    public class CharacterAnimator : MonoBehaviour
    {
        private const int InitialTrackIndex = 0;

        [SerializeField] private AnimationReferenceAsset _idleAnimation;
        [SerializeField] private AnimationReferenceAsset _startAttackAnimation;
        [SerializeField] private AnimationReferenceAsset _endAttackAnimation;
        [SerializeField] private EventDataReferenceAsset _shootEvent;

        private AnimationState _animationState;
        private WaitForSpineEvent _waitForSpineEvent;

        public void Initialize(AnimationState animationState)
        {
            _animationState = animationState;
            _waitForSpineEvent = new WaitForSpineEvent(_animationState, _shootEvent);
            _animationState.SetAnimation(InitialTrackIndex, _idleAnimation, true);
        }

        public IEnumerator SetStartAttackAnimation()
        {
            TrackEntry trackEntry = _animationState.SetAnimation(InitialTrackIndex, _startAttackAnimation, false);

            yield return new WaitForSpineAnimationComplete(trackEntry);
        }

        public IEnumerator SetAttackAnimation()
        {
            _animationState.SetAnimation(InitialTrackIndex, _endAttackAnimation, false);
            _animationState.AddAnimation(InitialTrackIndex, _idleAnimation, true, 0);

            yield return _waitForSpineEvent;
        }

        public void SetIdleAnimation()
        {
            _animationState.SetAnimation(InitialTrackIndex, _idleAnimation, false);
        }
    }
}
