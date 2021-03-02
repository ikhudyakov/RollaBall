using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{
    public sealed class BonusDisplay
    {
        private Text _bonus;
        public BonusDisplay(GameObject bonus)
        {
            _bonus = bonus.GetComponentInChildren<Text>();
            _bonus.text = String.Empty;
        }

        public void Display(int point)
        {
            _bonus.text = $"Вы набрали {point} очков";
        }
    }
}