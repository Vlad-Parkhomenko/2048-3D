using UnityEngine;

namespace Game2048.Gameplay
{
    public abstract class CubeBase : MonoBehaviour
    {
        public Rigidbody Rigidbody { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}