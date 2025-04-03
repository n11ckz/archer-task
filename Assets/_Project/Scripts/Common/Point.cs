using UnityEngine;

namespace Project
{
    public class Point : MonoBehaviour
    {
        public Vector2 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}
