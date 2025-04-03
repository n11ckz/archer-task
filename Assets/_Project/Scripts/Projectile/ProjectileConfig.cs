using UnityEngine;

namespace Project
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(ProjectileConfig), fileName = nameof(ProjectileConfig))]
    public class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField] public ProjectileType Type { get; private set; }
        [field: SerializeField, Min(0.1f)] public float Mass { get; private set; }
    }
}
