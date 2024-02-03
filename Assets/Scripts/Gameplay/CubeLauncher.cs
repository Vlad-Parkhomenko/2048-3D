using Game2048.Gameplay;
using Game2048.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game2048
{
    // TODO : Try to make non-monobeh
    public class CubeLauncher : MonoBehaviour
    {
        public CubeBase Cube;
        
        private IInputController _inputController;
        private MechanicsConfig _mechanicsConfig;
        
        [Inject]
        private void Construct(IInputController inputController, MechanicsConfig mechanicsConfig)
        {
            _inputController = inputController;
            _inputController.InputChanged += MoveCubeHorizontally;
            _inputController.InputFinished += LaunchCube;
            _mechanicsConfig = mechanicsConfig;
        }

        private void MoveCubeHorizontally(float delta)
        {
            Cube.Rigidbody.velocity = Vector3.right * delta * Time.deltaTime * _mechanicsConfig.AimSpeed;
        }

        private void LaunchCube()
        {
            Cube.Rigidbody.AddForce(Vector3.forward * _mechanicsConfig.LaunchForce, ForceMode.Impulse);
        }
    }
}
