using Alchemy.Inspector;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;

namespace Project
{
    public class Bootstrap : MonoBehaviour
    {
        [Title("Character")]
        [SerializeField] private Character _character;
        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private CharacterAimHandler _characterAimHandler;
        [SerializeField] private CharacterBodyRotator _characterBodyRotator;
        [SerializeField] private SkeletonAnimation _characterSkeletonAnimation;

        [Title("Other")]
        [SerializeField] private ProjectileSpawner _projectileSpawner;
        [SerializeField] private TrajectoryRenderer _trajectoryRenderer;

        private void Start()
        {
            InitializeTrajectory();
            InitializeSpawner();
            InitializeCharacter();
        }

        private void InitializeCharacter()
        {
            Skeleton skeleton = _characterSkeletonAnimation.Skeleton;
            AnimationState animationState = _characterSkeletonAnimation.AnimationState;
            IInput input = new DesktopInput(Camera.main);

            _characterAnimator.Initialize(animationState);
            _characterAimHandler.Initialize(_characterBodyRotator, _trajectoryRenderer);
            _characterBodyRotator.Initialize(skeleton);
            _character.Initialize(input, _characterAnimator, _characterAimHandler, _projectileSpawner);
        }

        private void InitializeSpawner()
        {
            ProjectileFactory projectileFactory = new ProjectileFactory();

            _projectileSpawner.Initialize(projectileFactory);
        }

        private void InitializeTrajectory()
        {
            TrajectorySegmentFactory trajectorySegmentFactory = new TrajectorySegmentFactory();
            TrajectoryCalculator trajectoryCalculator = new TrajectoryCalculator();

            _trajectoryRenderer.Initialize(trajectorySegmentFactory, trajectoryCalculator);
        }
    }
}
