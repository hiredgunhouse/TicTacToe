namespace TicTacToe.Exceptions
{
    public class BoardException : GameException
    {
        public BoardException() 
        {
        }

        public BoardException(string message) : base(message)
        {
        }
    }
}