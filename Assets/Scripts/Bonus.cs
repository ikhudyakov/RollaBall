using RollABall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus :InteractiveObject, IColor, IMotion
{
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
