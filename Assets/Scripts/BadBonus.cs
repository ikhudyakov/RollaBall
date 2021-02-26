using UnityEngine;

namespace RollABall
{
    public class BadBonus : Bonus
    {
        private PlayerBall _player;
        private BonusEvent bonusEvent;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>();
            SetColor(new Color(0f, 0f, 0f));
            bonusEvent = new BonusEvent();
            bonusEvent.Notify += BonusEvent_Notify;
        }

        protected override void Interaction()
        {
            base.Interaction();
            Destroy(_player.gameObject);
            bonusEvent.SendMessage();
        }

        private void BonusEvent_Notify(string message)
        {
            Debug.Log($"{message} : Уничтожение");
        }

        public override void Dispose()
        {
            base.Dispose();
            bonusEvent.Notify -= BonusEvent_Notify;
        }
    }
}