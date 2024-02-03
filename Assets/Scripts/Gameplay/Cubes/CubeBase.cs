using UnityEngine;
using Zenject;

namespace Game2048.Gameplay
{
    public abstract class CubeBase : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<CubeBase>
        {
            
        }
        
        public Rigidbody Rigidbody { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}