namespace RollABall
{
    internal sealed class BonusEvent
    {
        public delegate void BonusHandler(string message);
        public event BonusHandler Notify;

        public void SendMessage()
        {
            Notify($"Получен бонус");
        }
    }
}