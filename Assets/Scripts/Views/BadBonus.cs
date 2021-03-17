using System;
using UnityEngine;

namespace RollABall
{
    public class BadBonus : Bonus
    {
        public event Action ShowGameOverLabel = delegate { };

        private void Start()
        {
            SetColor(new Color(0f, 0f, 0f));
            IsInteractable = true;
        }

        protected override void Interaction()
        {
            base.Interaction();
            ShowGameOverLabel.Invoke();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}