using UnityEngine;

namespace RollABall
{
    public sealed class CameraController : IExecute
    {
        private Transform PlayerTransform;
        private Transform CameraTransform;
        private Vector3 _offset;
        private float _shakeDuration;
        private float shakeAmount = 0.7f;
        private float decreaseFactor = 1.0f;

        public float ShakeDuration { get => _shakeDuration; set => _shakeDuration = value; }

        public CameraController(Transform player, Transform CameraTransform)
        {
            this.CameraTransform = CameraTransform;
            PlayerTransform = player;
            _offset = CameraTransform.position - PlayerTransform.position;
        }

        public void Shake()
        {
            CameraTransform.position = PlayerTransform.position + _offset;
            if (ShakeDuration > 0)
            {
                CameraTransform.localPosition = CameraTransform.position + UnityEngine.Random.insideUnitSphere * shakeAmount;
                ShakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                ShakeDuration = 0f;
                CameraTransform.position = PlayerTransform.position + _offset;
            }
        }

        public void SetShakeDuration()
        {
            ShakeDuration = 0.5f;
        }

        public void Execute()
        {
            Shake();
        }
    }
}