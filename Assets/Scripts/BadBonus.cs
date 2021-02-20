using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class BadBonus : Bonus
    {
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            SetColor(new Color(0f, 0f, 0f));
        }

        protected override void Interaction()
        {
            base.Interaction();
            Destroy(_player);
        }
    }
}