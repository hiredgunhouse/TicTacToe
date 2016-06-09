namespace TicTacToe.Exceptions
{
    public class PositionOutsideBoardBoundariesException : BoardException
    {
        public PositionOutsideBoardBoundariesException()
        {
        }

        public PositionOutsideBoardBoundariesException(string message) : base(message)
        {
        }
    }
}