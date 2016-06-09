namespace TicTacToe.Tests.Unit
{
    internal class TestableBoard : Board
    {
        public static Board Create(string boardState)
        {
            var board = new TestableBoard();

            for (int i = 0; i < 9; i++)
            {
                var row = i/3 + 1;
                var col = i%3 + 1;

                board.Set(row, col, boardState[i]);
            }

            return board;
        }
    }
}