using UnityEngine;

namespace RollABall
{
    public sealed class CameraController : MonoBehaviour
    {
        public Player Player;
        private Vector3 _offset;
        private float _shakeDuration;
        private Vector3 originalPos;
        private float shakeAmount = 0.7f;
        private float decreaseFactor = 1.0f;

        public float ShakeDuration { get => _shakeDuration; set => _shakeDuration = value; }

        private void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        private void OnEnable()
        {
            originalPos = transform.localPosition;
        }

        private void LateUpdate()
        {
            Shake();
        }

        private void Shake()
        {
            transform.position = Player.transform.position + _offset;
            if (ShakeDuration > 0)
            {
                transform.localPosition = transform.position + Random.insideUnitSphere * shakeAmount;
                ShakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                ShakeDuration = 0f;
                transform.position = Player.transform.position + _offset;
            }
        }
    }
}