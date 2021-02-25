using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public class GoodBonus : Bonus
    {
        private GameObject _player;
        private int _bonusPoints = 5;
        private BonusDisplay _bonusDisplay;

        private void Start()
        {
            _bonusDisplay = new BonusDisplay();
            _player = GameObject.FindGameObjectWithTag("Player");
            SetColor(new Color(0f, 255f, 0f));
        }

        protected override void Interaction()
        {
            base.Interaction();
            _player.GetComponent<PlayerBall>().Score += _bonusPoints;
            _bonusDisplay.Display(_bonusPoints);
        }
    }
}