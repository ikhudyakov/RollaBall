using System;
using UnityEngine;

namespace RollABall
{
    public abstract class Player : MonoBehaviour
    {
        internal int Score;
        internal float Speed;
        internal Rigidbody _rigidbody;
        [SerializeField] internal PlayerSettings playerSettings;

        private void Start()
        {
            Speed = playerSettings.Speed;
            Score = 0;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public abstract void Move(float x, float y);
    }
}