using System;
using UnityEngine;

namespace Game2048.PlayerInput
{
    public class MouseInputController : MonoBehaviour, IInputController
    {
        private readonly KeyCode _controlKey = KeyCode.Mouse0;

        private Vector2 _oldMousePosition;
        
        public event Action<float> InputChanged; 
        public event Action InputFinished;
        
        private void Update()
        {
            if (Input.GetKeyDown(_controlKey))
            {
                _oldMousePosition = Input.mousePosition;
            }
            
            if (Input.GetKey(_controlKey))
            {
                EvaluateInputDelta();
            }

            if (Input.GetKeyUp(_controlKey))
            {
                InputFinished?.Invoke();
            }
        }

        private void EvaluateInputDelta()
        {
            Vector2 newMousePosition = Input.mousePosition;
            Vector2 delta = newMousePosition - _oldMousePosition;
            _oldMousePosition = newMousePosition;
            InputChanged?.Invoke(delta.x);
        }
    }
}