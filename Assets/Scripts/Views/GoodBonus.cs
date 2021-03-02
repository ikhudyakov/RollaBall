using System;
using UnityEngine;

namespace RollABall
{
    public class GoodBonus : Bonus
    {
        private int _bonusPoints = 5;
        public event Action ShakeCamera = delegate { };
        public event Action<int> SetBonusPoint = delegate (int point) { };

        private void Awake()
        {
            SetColor(new Color(0f, 255f, 0f));
            IsInteractable = true;
        }

        protected override void Interaction()
        {
            base.Interaction();
            ShakeCamera.Invoke();
            SetBonusPoint(_bonusPoints);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}