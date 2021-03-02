namespace RollABall
{
    public sealed class PlayerBall : Player, IExecute
    {
        public void Execute()
        {
            Move();
        }
    }
}
