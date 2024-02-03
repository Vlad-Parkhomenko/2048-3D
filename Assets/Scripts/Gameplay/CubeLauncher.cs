using System;
using System.Threading.Tasks;
using Game2048.Gameplay;
using Game2048.PlayerInput;
using UnityEngine;

namespace Game2048
{
    // TODO : Try to make non-monobeh
    public class CubeLauncher
    {
        private IInputController _inputController;
        private MechanicsConfig _mechanicsConfig;
        private CubeSpawner _cubeSpawner;

        private CubeBase _currentCube;
        private float _lastSpawnTime;
        
        private CubeLauncher(IInputController inputController, MechanicsConfig mechanicsConfig, CubeSpawner cubeSpawner)
        {
            _inputController = inputController;
            _inputController.InputChanged += MoveCubeHorizontally;
            _inputController.InputFinished += LaunchCube;
            _mechanicsConfig = mechanicsConfig;
            _cubeSpawner = cubeSpawner;
            PrepareCube();
        }

        private void MoveCubeHorizontally(float delta)
        {
            if (_currentCube == null)
            {
                return;
            }

            float speedMultiplier = delta * Time.deltaTime * _mechanicsConfig.AimSpeed;
            _currentCube.Rigidbody.velocity = Vector3.right * speedMultiplier;
        }

        private void LaunchCube()
        {
            if (_currentCube == null)
            {
                return;
            }
            
            if (Time.time - _lastSpawnTime < _mechanicsConfig.SpawnCooldown)
            {
                return;
            }
            
            _currentCube.Rigidbody.AddForce(Vector3.forward * _mechanicsConfig.LaunchForce, ForceMode.Impulse);
            _currentCube = null;
            PrepareCube();
        }

        private async void PrepareCube()
        {
            await Task.Delay(TimeSpan.FromSeconds(_mechanicsConfig.SpawnCooldown));
            _currentCube = _cubeSpawner.SpawnCubeForShoot();
        }
    }
}