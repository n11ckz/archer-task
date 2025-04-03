using UnityEngine;

namespace Project
{
    public class TrajectorySegment : MonoBehaviour
    {
        public void Setup(Vector2 position, Vector2 scale)
        {
            transform.position = position;
            transform.localScale = scale;
            gameObject.Enable();
        }
    }
}
