using UnityEngine;

namespace RollABall
{
    public class GoodBonus : Bonus
    {
        private PlayerBall _player;
        private int _bonusPoints = 5;
        private BonusDisplay _bonusDisplay;
        private BonusEvent bonusEvent;

        private void Start()
        {
            _bonusDisplay = new BonusDisplay();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>();
            SetColor(new Color(0f, 255f, 0f));
            bonusEvent = new BonusEvent();
            bonusEvent.Notify += BonusEvent_Notify;
        }

        protected override void Interaction()
        {
            base.Interaction();
            _player.Score += _bonusPoints;
            _bonusDisplay.Display(_bonusPoints);
            bonusEvent.SendMessage();
        }

        private void BonusEvent_Notify(string message)
        {
            Debug.Log($"{message} : {_bonusPoints} очков");
            Camera.main.GetComponent<CameraController>().ShakeDuration = 0.1f;
        }

        public override void Dispose()
        {
            base.Dispose();
            bonusEvent.Notify -= BonusEvent_Notify;
        }
    }
}