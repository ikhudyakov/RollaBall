using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

public sealed class BonusDisplay : MonoBehaviour
{
    public void Display(int value)
    {
        Log($"Получено {value} очков");
    }
}
