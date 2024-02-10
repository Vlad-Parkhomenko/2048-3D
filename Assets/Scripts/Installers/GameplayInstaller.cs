using Game2048.Configs;
using Game2048.Gameplay;
using UnityEngine;
using Zenject;

namespace Game2048.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private MechanicsConfig _mechanicsConfig;
        [SerializeField] private CubesConfig _cubesConfig;
        [SerializeField] private ScoreCube _scoreCube;

        public override void InstallBindings()
        {
            Container.BindInstance(_mechanicsConfig).AsSingle();
            Container.BindInstance(_cubesConfig).AsSingle();
            Container.BindMemoryPool<ScoreCube, CubeBase.Pool>().FromComponentInNewPrefab(_scoreCube).AsSingle();
            Container.Bind<CubeSpawner>().AsSingle();
            Container.Bind<CubePropertiesAssigner>().AsSingle();
            Container.Bind<CubeLauncher>().AsSingle().NonLazy();
        }
    }
}