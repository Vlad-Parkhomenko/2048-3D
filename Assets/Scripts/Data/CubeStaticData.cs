using System;
using UnityEngine;

namespace Game2048.Data
{
    [Serializable]
    public struct CubeStaticData
    {
        public int Id;
        public int Score;
        public string SpriteName;
        public int AppearProbability;
        public Texture2D Texture;
    }
}