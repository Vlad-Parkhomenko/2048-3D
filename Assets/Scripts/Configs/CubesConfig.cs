using System;
using System.Collections.Generic;
using System.Linq;
using Game2048.Data;
using UnityEngine;
using UnityEngine.U2D;

namespace Game2048.Configs
{
    [CreateAssetMenu(fileName = nameof(CubesConfig), menuName = "Configs/Cubes Config")]
    public class CubesConfig : ScriptableObject
    {
        public const int TotalProbability = 100;
        
        [field: SerializeField] public CubeStaticData[] CubeDataArray { get; private set; }
        [SerializeField] private SpriteAtlas _cubesAtlas;

        private Dictionary<int, CubeStaticData> _cubeDataDictionary;

        private void OnValidate()
        {
            int totalProbability = CubeDataArray.Sum(cube => cube.AppearProbability);
            if (totalProbability != TotalProbability)
            {
                throw new InvalidOperationException("Sum of probabilities must be equal 100");
            }
            
            Debug.Log("Cube config validated successfully");
        }

        public CubeStaticData GetCubeData(int id)
        {
            TryInitializeDictionary();

            return _cubeDataDictionary[id];
        }
        
        public Texture2D GetCubeTexture(int id)
        {
            TryInitializeDictionary();

            Sprite sprite = _cubesAtlas.GetSprite(_cubeDataDictionary[id].SpriteName);
            return sprite.texture;
        }

        private void TryInitializeDictionary()
        {
            if (_cubeDataDictionary != null)
            {
                return;
            }
            
            _cubeDataDictionary = new Dictionary<int, CubeStaticData>();
            
            foreach (CubeStaticData cube in CubeDataArray)
            {
                _cubeDataDictionary.Add(cube.Id, cube);
            }
        }
    }
}
