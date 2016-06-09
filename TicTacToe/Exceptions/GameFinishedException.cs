namespace TicTacToe.Exceptions
{
    public class GameFinishedException : GameException
    {
        public GameFinishedException(string message) : base(message)
        {
        }
    }
}