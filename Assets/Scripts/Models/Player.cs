using System;
using UnityEngine;

namespace RollABall
{
    public class Player : MonoBehaviour
    {
        private float Speed;
        private int Score;
        private Rigidbody _rigidbody;
        [SerializeField] private PlayerSettings playerSettings;
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

        private void Start()
        {
            Speed = playerSettings.Speed;
            Score = 0;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rigidbody.AddForce(movement * Speed);
        }
    }
}