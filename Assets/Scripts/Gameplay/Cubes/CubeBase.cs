using Game2048.Data;
using UnityEngine;
using Zenject;

namespace Game2048.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class CubeBase : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<CubeBase>
        {
            
        }

        private MeshRenderer _meshRenderer;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        public Rigidbody Rigidbody { get; private set; }
        
        public CubeDynamicData Data { get; private set; }
        
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetTexture(Texture2D texture)
        {
            _meshRenderer.material.SetTexture(MainTex, texture);
        }
        
        public void SetData(CubeDynamicData data)
        {
            Data = data;
        }
    }
}