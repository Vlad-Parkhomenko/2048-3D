using UnityEngine;

namespace Game2048
{
    [CreateAssetMenu(fileName = nameof(MechanicsConfig), menuName = "Configs/Mechanics Config")]
    public class MechanicsConfig : ScriptableObject
    {
        [field: SerializeField] public float LaunchForce { get; private set; }
        [field: SerializeField] public float AimSpeed { get; private set; }
    }
}
