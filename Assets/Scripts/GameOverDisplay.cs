using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall
{
    public sealed class GameOverDisplay
    {
        private Text _endGame;

        public GameOverDisplay(GameObject endGame)
        {
            _endGame = endGame.GetComponentInChildren<Text>();
            _endGame.text = String.Empty;
        }

        public void GameOver()
        {
            _endGame.text = $"Конец игры";
        }
    }
}