namespace TicTacToe.Exceptions
{
    public class InvalidMoveException : GameException
    {
        public InvalidMoveException()
        {
        }

        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}