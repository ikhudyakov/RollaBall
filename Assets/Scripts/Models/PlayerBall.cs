using System;
using UnityEngine;

namespace RollABall
{
    public sealed class PlayerBall : Player
    {
        
        public event Action<int> ShowScore = delegate (int point) { };

        public void SetBonusPoint(int point)
        {
            Score += point;
            Debug.Log($"Текущие очки: {Score}");
            ShowScore.Invoke(Score);
        }

        internal void SetBonusSpeedPoint(float point)
        {
            Speed += point;
            Debug.Log($"Текущая скорость: {Speed}");
        }

        public override void Move(float moveHorizontal, float moveVertical)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(movement * Speed);
        }
    }
}
