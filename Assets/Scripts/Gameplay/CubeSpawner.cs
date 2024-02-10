using Game2048.Configs;

namespace Game2048.Gameplay
{
    public class CubeSpawner
    {
        private readonly MechanicsConfig _mechanicsConfig;
        private CubeBase.Pool _cubesPool;
        
        private CubeSpawner(MechanicsConfig mechanicsConfig, CubeBase.Pool cubesPool)
        {
            _mechanicsConfig = mechanicsConfig;
            _cubesPool = cubesPool;
        }

        public CubeBase SpawnCubeForShoot()
        {
            CubeBase cube = _cubesPool.Spawn();
            cube.transform.position = _mechanicsConfig.SpawnPosition;
            return cube;
        }
    }
}
