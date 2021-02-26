using static UnityEngine.Debug;

namespace RollABall
{
    public sealed class BonusDisplay
    {
        public void Display(int value)
        {
            Log($"Получено {value} очков");
        }
    }
}