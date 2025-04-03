using UnityEngine;

namespace Project
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;
        [SerializeField] private Rigidbody2D _rigidbody;

        public ProjectileType Type => _config.Type;
        public float Mass => _config.Mass;

        private bool _isInitialized;

        private void Update()
        {
            if (_isInitialized == false || _rigidbody.velocity.sqrMagnitude < 0.01f)
                return;

            _rigidbody.rotation = Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg;
        }

        public void Initialize()
        {
            _rigidbody.mass = Mass;
            _isInitialized = true;
        }

        public void Launch(Vector2 velocity) =>
            _rigidbody.velocity = velocity;
    }
}
