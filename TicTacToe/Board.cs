using System.Text;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class Board
    {
        protected char[,] _board;

        private const int ROWS = 3;
        private const int COLS = 3;

        private const char EmptyMark = ' ';

        public Board()
        {
            _board = new char[ROWS, COLS];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int x = 1; x <= ROWS; x++)
                for (int y = 1; y <= COLS; y++)
                    Set(x, y, EmptyMark);
        }

        protected char Get(int row, int col)
        {
            return _board[row - 1, col - 1];
        }

        protected void Set(int row, int col, char mark)
        {
            _board[row - 1, col - 1] = mark;
        }

        public virtual void PutMark(char mark, int row, int col)
        {
            if (PositionIsOutsideBoardBoundaries(row, col))
                throw new PositionOutsideBoardBoundariesException("Position " + row + ", " + col + " is outside of boundaries.");

            if (PositionTaken(row, col))
                throw new PositionTakenException("Position " + row + ", " + col + " is taken.");

            Set(row, col, mark);
        }

        private bool PositionIsOutsideBoardBoundaries(int row, int col)
        {
            return row > ROWS || row < 1 || col > COLS || col < 1;
        }

        private bool PositionTaken(int row, int col)
        {
            return Get(row, col) != EmptyMark;
        }

        public virtual bool IsBoardFull()
        {
            for (int row = 1; row <= ROWS; row++)
                for (int col = 1; col <= COLS; col++)
                    if (Get(row, col) == EmptyMark) return false;

            return true;
        }

        public string GetRow(int row)
        {
            return new StringBuilder()
                .Append(Get(row, 1))
                .Append(Get(row, 2))
                .Append(Get(row, 3))
                .ToString();
        }

        public string GetColumn(int col)
        {
            return new StringBuilder()
                .Append(Get(1, col))
                .Append(Get(2, col))
                .Append(Get(3, col))
                .ToString();
        }

        public string GetAxisLeftTopToRightBottm()
        {
            return new StringBuilder()
                .Append(Get(1, 1))
                .Append(Get(2, 2))
                .Append(Get(3, 3))
                .ToString();
        }

        public string GetAxisLeftBottomToRightTop()
        {
            return new StringBuilder()
                .Append(Get(3, 1))
                .Append(Get(2, 2))
                .Append(Get(1, 3))
                .ToString();
        }
    }
}