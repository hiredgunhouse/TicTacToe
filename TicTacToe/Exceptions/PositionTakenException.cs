namespace TicTacToe.Exceptions
{
    public class PositionTakenException : BoardException
    {
        public PositionTakenException()
        {
        }

        public PositionTakenException(string message) : base(message)
        {
        }
    }
}