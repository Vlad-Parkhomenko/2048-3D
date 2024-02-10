using System;
using System.Collections.Generic;
using System.Linq;
using Game2048.Configs;
using Game2048.Data;
using UnityEngine;
using Random = System.Random;

namespace Game2048.Gameplay
{
    public class CubePropertiesAssigner
    {
        private readonly CubesConfig _cubesConfig;
        private readonly Dictionary<int, int> _cubeIds = new();
        private readonly Random _random = new();
        
        private CubePropertiesAssigner(CubesConfig cubesConfig)
        {
            _cubesConfig = cubesConfig;
            SetupIdsDictionary();
        }
        
        public void AssignCubeProperties(CubeBase cube)
        {
            int cubeId = AssignId();
            CubeStaticData cubeStaticData = _cubesConfig.GetCubeData(cubeId);
            cube.SetTexture(cubeStaticData.Texture);
        }
        
        private int AssignId()
        {
            int probability = _random.Next(0, CubesConfig.TotalProbability + 1);
            bool HasGreaterOrEqualProbability(KeyValuePair<int, int> probabilityIdPair)
            {
                return 100 - probability <= probabilityIdPair.Key;
            }

            int id = -1;
            if (!_cubeIds.Any(HasGreaterOrEqualProbability))
            {

                id = _cubeIds.Values.First();
                Debug.Log($"[CubePropertiesAssigner] First case Probability is {probability}, id is {id}");
                return id;
            }
            
            id = _cubeIds.Last(HasGreaterOrEqualProbability).Value;
            Debug.Log($"[CubePropertiesAssigner] Second case Probability is {probability}, id is {id}");
            return id;
        }
        
        private void SetupIdsDictionary()
        {
            var sortedCubes = _cubesConfig.CubeDataArray.OrderByDescending(cube =>
            {
                return cube.AppearProbability;
            });
            int probabilitySum = 0;
            foreach (CubeStaticData cubeData in sortedCubes)
            {
                if (cubeData.AppearProbability == 0)
                {
                    continue;
                }

                probabilitySum += cubeData.AppearProbability;
                _cubeIds.Add(probabilitySum, cubeData.Id);
            }
        }
    }
}
