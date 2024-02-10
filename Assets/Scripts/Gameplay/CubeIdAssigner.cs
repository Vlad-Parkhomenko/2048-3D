using System;
using System.Collections.Generic;
using System.Linq;
using Game2048.Configs;
using Game2048.Data;

namespace Game2048.Gameplay
{
    public class CubeIdAssigner
    {
        private readonly CubesConfig _cubesConfig;
        private readonly Dictionary<int, int> _cubeIds = new();
        private readonly Random _random = new Random();
        
        private CubeIdAssigner(CubesConfig cubesConfig)
        {
            _cubesConfig = cubesConfig;
            SetupIdsDictionary();
        }

        public int AssignId()
        {
            int probability = _random.Next(0, CubesConfig.TotalProbability + 1);
            int id = _cubeIds.First(idPair => probability >= idPair.Key).Value;
            return id;
        }
        
        private void SetupIdsDictionary()
        {
            var sortedCubes = _cubesConfig.CubeDataArray.OrderBy(cube => cube.AppearProbability);
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
