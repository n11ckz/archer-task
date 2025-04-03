using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class TrajectorySegmentFactory
    {
        private readonly TrajectorySegment _segmentPrefab;

        public TrajectorySegmentFactory() =>
            _segmentPrefab = Resources.Load<TrajectorySegment>(AssetPaths.TrajectorySegmentPath);

        public IEnumerable<TrajectorySegment> CreateSegmentsLazy(Transform parent, int count)
        {
            for (int i = 0; i < count; i++)
                yield return Object.Instantiate(_segmentPrefab, parent);
        }
    }
}
