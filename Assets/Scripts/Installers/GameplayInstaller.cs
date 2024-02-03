using UnityEngine;
using Zenject;

namespace Game2048.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private MechanicsConfig _mechanicsConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_mechanicsConfig).AsSingle();
        }
    }
}