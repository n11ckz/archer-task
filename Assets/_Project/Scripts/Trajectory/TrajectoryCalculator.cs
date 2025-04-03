using UnityEngine;

namespace Project
{
    public class TrajectoryCalculator
    {
        private readonly Vector2 _initialSegmentScale = Vector2.one;

        public Vector2 CalculateNextPosition(Vector2 launchPosition, Vector2 startVelocity, float elaspedTime)
        {
            Vector2 positionWithoutGravity = launchPosition + startVelocity * elaspedTime;
            Vector2 gravityOffset = Vector2.down * (0.5f * Physics2D.gravity.y * elaspedTime * elaspedTime);

            return positionWithoutGravity - gravityOffset;
        }

        public Vector2 CalculateScale(int i, int segmentsCount)
        {
            float invertedProgress = (segmentsCount - i) / (float)segmentsCount;

            return _initialSegmentScale * invertedProgress;
        }
    }
}
