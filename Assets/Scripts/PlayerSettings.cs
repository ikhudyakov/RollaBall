using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "PlayerSettings", order = 51)]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed { get => _speed; }
}
