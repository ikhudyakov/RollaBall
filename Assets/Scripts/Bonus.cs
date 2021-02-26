using UnityEngine;

namespace RollABall
{
    public class Bonus : InteractiveObject, IColor, IMotion
    {
        public string InfoBonus { get; set; }

        private void Start()
        {
            InfoBonus = nameof(Bonus);
        }

        private void Update()
        {
            Motion();
        }

        public void Motion()
        {
            transform.localScale = new Vector3(Mathf.PingPong(Time.time, 1f - 0.5f) + 0.5f,
                                                Mathf.PingPong(Time.time, 1f - 0.5f) + 0.5f,
                                                Mathf.PingPong(Time.time, 1f - 0.5f) + 0.5f);
        }

        public void SetColor(Color color)
        {
            GetComponent<Renderer>().material.color = color;
        }
    }
}