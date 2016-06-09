namespace TicTacToe.Exceptions
{
    public class BoardIsFullException : BoardException
    {
        public BoardIsFullException(string message) : base(message)
        {
        }
    }
}