using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall
{
    public sealed class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }
    }
}
