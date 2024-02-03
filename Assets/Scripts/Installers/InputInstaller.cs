using Game2048.PlayerInput;
using Zenject;

namespace Game2048.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputController>().To<MouseInputController>().FromComponentInHierarchy().AsSingle();
        }
    }
}