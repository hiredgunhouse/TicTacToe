using System;

namespace TicTacToe.Exceptions
{
    public class GameException : Exception
    {
        public GameException()
        {
        }

        public GameException(string message) : base(message)
        {
        }
    }
}