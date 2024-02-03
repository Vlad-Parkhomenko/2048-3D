using System;

namespace Game2048.PlayerInput
{
    public interface IInputController
    {
        event Action<float> InputChanged; 
        event Action InputFinished;
    }
}