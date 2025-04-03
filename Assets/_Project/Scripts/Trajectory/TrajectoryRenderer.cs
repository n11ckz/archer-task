using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class TrajectoryRenderer : MonoBehaviour
    {
        private const int Offset = 1;
        
        [SerializeField] private Point _shotPoint;

        [SerializeField, Range(8, 16)] private int _segmentsCount; 
        [SerializeField, Min(0.0f)] private float _timeStep;

        private TrajectorySegmentFactory _segmentFactory;
        private TrajectoryCalculator _calculator;
        private List<TrajectorySegment> _segments;

        public void Initialize(TrajectorySegmentFactory segmentFactory, TrajectoryCalculator calculator)
        {
            _segmentFactory = segmentFactory;
            _calculator = calculator;

            CreateSegments();
        }

        public void Render(Vector2 startVelocity)
        {
            for (int i = 0; i < _segments.Count; i++)
            {
                float elapsedTime = (i + Offset) * _timeStep;
                Vector2 nextPosition = _calculator.CalculateNextPosition(_shotPoint.Position, startVelocity, elapsedTime);
                Vector2 scale = _calculator.CalculateScale(i, _segments.Count);

                _segments[i].Setup(nextPosition, scale);
            }
        }

        public void Clear()
        {
            foreach (TrajectorySegment segment in _segments)
                segment.gameObject.Disable();
        }

        private void CreateSegments()
        {
            _segments = new List<TrajectorySegment>(_segmentsCount);

            foreach (TrajectorySegment segment in _segmentFactory.CreateSegmentsLazy(transform, _segmentsCount))
                _segments.Add(segment);
        }
    }
}
