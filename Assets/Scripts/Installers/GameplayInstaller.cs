using Game2048.Gameplay;
using UnityEngine;
using Zenject;

namespace Game2048.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private MechanicsConfig _mechanicsConfig;
        [SerializeField] private ScoreCube _scoreCube;

        public override void InstallBindings()
        {
            Container.BindInstance(_mechanicsConfig).AsSingle();
            Container.BindMemoryPool<ScoreCube, CubeBase.Pool>().FromComponentInNewPrefab(_scoreCube).AsSingle();
            Container.Bind<CubeSpawner>().AsSingle();
            Container.Bind<CubeLauncher>().AsSingle().NonLazy();
        }
    }
}