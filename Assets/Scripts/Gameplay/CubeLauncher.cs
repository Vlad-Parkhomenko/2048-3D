using System;
using System.Threading.Tasks;
using Game2048.Configs;
using Game2048.PlayerInput;
using UnityEngine;

namespace Game2048.Gameplay
{
    public class CubeLauncher
    {
        private readonly IInputController _inputController;
        private readonly MechanicsConfig _mechanicsConfig;
        private readonly CubeSpawner _cubeSpawner;
        private readonly CubePropertiesAssigner _cubePropertiesAssigner;

        private CubeBase _currentCube;
        private float _lastSpawnTime;
        
        private CubeLauncher(IInputController inputController, MechanicsConfig mechanicsConfig, CubeSpawner cubeSpawner,
            CubePropertiesAssigner cubePropertiesAssigner)
        {
            _inputController = inputController;
            _inputController.InputChanged += MoveCubeHorizontally;
            _inputController.InputFinished += LaunchCube;
            _mechanicsConfig = mechanicsConfig;
            _cubeSpawner = cubeSpawner;
            _cubePropertiesAssigner = cubePropertiesAssigner;
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
            _cubePropertiesAssigner.AssignCubeProperties(_currentCube);
        }
    }
}