using UnityEngine;

namespace Project
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private Point _shotPoint;
        [SerializeField, Range(0.0f, 2.0f)] private float _threshold;

        private ProjectileFactory _projectileFactory;

        public void Initialize(ProjectileFactory projectileFactory) =>
            _projectileFactory = projectileFactory;

        public void TrySpawn(Vector2 startVelocity, Vector2 direction, ProjectileType projectileType)
        {
            if (direction.magnitude < _threshold)
                return;

            Projectile projectile = _projectileFactory.Create(projectileType);
            projectile.transform.SetPositionAndRotation(_shotPoint.Position, _shotPoint.Rotation);
            projectile.Launch(startVelocity / projectile.Mass);
        }
    }
}
