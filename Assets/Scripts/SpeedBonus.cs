using UnityEngine;

namespace RollABall
{
    public class SpeedBonus : Bonus
    {
        private GameObject _player;
        private float _bonusSpeedPoint = 5f;
        private BonusEvent bonusEvent;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            SetColor(new Color(0f, 0, 255f));
            bonusEvent = new BonusEvent();
            bonusEvent.Notify += BonusEvent_Notify;
        }

        protected override void Interaction()
        {
            base.Interaction();
            bonusEvent.SendMessage();
            _player.GetComponent<PlayerBall>().Speed += _bonusSpeedPoint;
        }

        private void BonusEvent_Notify(string message)
        {
            Debug.Log($"{message} : Ускорение");
            Camera.main.GetComponent<CameraController>().ShakeDuration = 0.1f;
        }

        public override void Dispose()
        {
            base.Dispose();
            bonusEvent.Notify -= BonusEvent_Notify;
        }
    }
}