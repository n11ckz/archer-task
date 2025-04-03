using System.Linq;
using UnityEngine;

namespace Project
{
    public class ProjectileFactory
    {
        private readonly Projectile[] _projectiles;

        public ProjectileFactory() =>
            _projectiles = Resources.LoadAll<Projectile>(AssetPaths.ProjectilePrefabsPath);

        public Projectile Create(ProjectileType projectileType)
        {
            if (TryFindProjectilePrefab(projectileType, out Projectile prefab) == false)
                return null;

            // TODO: maybe need a object pool for more perfomance
            Projectile projectile = Object.Instantiate(prefab);
            projectile.Initialize();

            return projectile;
        }

        private bool TryFindProjectilePrefab(ProjectileType projectileType, out Projectile prefab)
        {
            prefab = _projectiles.FirstOrDefault((projectile) => projectile.Type == projectileType);

            if (prefab == null)
                Debug.LogError($"Projectile <{projectileType}> not found");

            return prefab != null;
        }
    }
}
