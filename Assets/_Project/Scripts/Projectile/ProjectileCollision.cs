using System;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileCollision : MonoBehaviour
    {
        public event Action Collided;

        [SerializeField] private Rigidbody2D _rigidbody;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            ResetRigidbody();
            Collided?.Invoke();
        }

        private void ResetRigidbody()
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.angularVelocity = 0;
            _rigidbody.isKinematic = true;
        }
    }
}
