using UnityEditor;
using UnityEngine;

namespace RollABall
{
    public class BonusesWindow : EditorWindow
    {
        public static GameObject GoodBonus;
        public static GameObject BadBonus;
        public static GameObject SpeedBonus;
        public static int countGood;
        public static int countBad;
        public static int countSpeed;
        private float x;
        private float z;
        public bool _groupEnabled;
        public static GameObject createZone;


        private void OnGUI()
        {
            createZone = GameObject.FindGameObjectWithTag("CreateZone");

            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            GoodBonus =
               EditorGUILayout.ObjectField("GoodBonus",
                     GoodBonus, typeof(GameObject), true)
                  as GameObject;
            countGood = EditorGUILayout.IntSlider("Количество объектов", countGood, 1, 10);
            BadBonus =
               EditorGUILayout.ObjectField("BadBonus",
                     BadBonus, typeof(GameObject), true)
                  as GameObject;
            countBad = EditorGUILayout.IntSlider("Количество объектов", countBad, 1, 10);
            SpeedBonus =
               EditorGUILayout.ObjectField("SpeedBonus",
                     SpeedBonus, typeof(GameObject), true)
                  as GameObject;
            countSpeed = EditorGUILayout.IntSlider("Количество объектов", countSpeed, 1, 10);

            var add = GUILayout.Button("Добавить бонусы на сцену");
            if (add)
            {
                GameObject root = new GameObject("Bonuses");
                if (GoodBonus && BadBonus && SpeedBonus)
                {
                    GameObject gb = new GameObject("Good");
                    gb.transform.parent = root.transform;
                    CreateBonus(GoodBonus, gb, countGood);
                    GameObject bb = new GameObject("Bad");
                    bb.transform.parent = root.transform;
                    CreateBonus(BadBonus, bb, countBad);
                    GameObject sb = new GameObject("Speed");
                    sb.transform.parent = root.transform;
                    CreateBonus(SpeedBonus, sb, countSpeed);
                }
            }
            var delete = GUILayout.Button("Удалить бонусы со сцены");
            if (delete)
            {
                DestroyImmediate(GameObject.Find("Bonuses"));
            }

            void CreateBonus(GameObject bonus, GameObject root, int count)
            {
                while (count > 0)
                {
                    bool check = true;
                    x = Random.Range(-50f, 50f);
                    z = Random.Range(-50f, 50f);
                    var coll = Physics.OverlapSphere(new Vector3(x, createZone.transform.position.y, z), 1f);
                    if (coll.Length <= 0)
                    {
                        check = false;
                    }
                    foreach (Collider col in coll)
                    {
                        if (col.GetComponent<Collider>().tag != "CreateZone")
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        var b = Instantiate(bonus, new Vector3(x, createZone.transform.position.y + 0.5f, z), createZone.transform.rotation);
                        b.name = bonus.name + count;
                        b.transform.parent = root.transform;
                        count--;
                    }
                }
            }
        }
    }
}
