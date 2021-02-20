using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class SpeedBonus : Bonus
    {
        private GameObject _player;
        private float _bonusSpeedPoint = 5f;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            SetColor(new Color(0f, 0, 255f));
        }

        protected override void Interaction()
        {
            base.Interaction();
            _player.GetComponent<PlayerBall>().Speed += _bonusSpeedPoint;
        }
    }
}