using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RollABall
{
    public class MenuItems
    {
        [MenuItem("Создать/Бонусы ")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(BonusesWindow), false, "Бонусы");
        }
    }
}

