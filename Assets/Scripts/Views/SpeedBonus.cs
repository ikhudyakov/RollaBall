using System;
using UnityEngine;

namespace RollABall
{
    public class SpeedBonus : Bonus
    {
        private float _bonusSpeedPoint = 2f;
        public event Action ShakeCamera = delegate { };
        public event Action<float> SetBonusSpeedPoint = delegate (float point) { };


        private void Awake()
        {
            SetColor(new Color(0f, 0, 255f));
            IsInteractable = true;
        }

        protected override void Interaction()
        {
            base.Interaction();
            ShakeCamera.Invoke();
            SetBonusSpeedPoint.Invoke(_bonusSpeedPoint);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}