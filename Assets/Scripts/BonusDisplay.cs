using static UnityEngine.Debug;

public sealed class BonusDisplay
{
    public void Display(int value)
    {
        Log($"Получено {value} очков");
    }
}
