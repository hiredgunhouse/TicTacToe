using System;
using TicTacToe.Exceptions;

namespace TicTacToe
{
    public class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Board _board;

        private Player _lastPlayer;

        private const char Player1Mark = 'X';
        private const char Player2Mark = 'O';

        private static readonly string Player1Pattern = new String(Player1Mark, 3);
        private static readonly string Player2Pattern = new String(Player2Mark, 3);

        public Game(Player player1, Player player2) : this(player1, player2, new Board())
        {
        }

        // a convenience constructor for easier testing
        public Game(Player player1, Player player2, Board board)
        {
            _player1 = player1;
            _player2 = player2;
            _board = board;
        }

        public void PutMark(Player player, int row, int col)
        {
            if (player != _player1 && player != _player2)
                throw new GameException("Unknown player.");

            if (IsThisTheFirstMove())
                if (!IsPlayer1(player))
                    throw new GameException("Player 1 must start the game.");

            if (IsThereAWin())
                throw new GameFinishedException("Game is finished cause there is a winner.");

            if (IsDraw())
                throw new GameFinishedException("Game is finished cause there is a draw.");

            if (IsTheSamePlayerAsInLastMove(player))
                throw new InvalidMoveException();

            _board.PutMark(GetPlayerMark(player), row, col);

            _lastPlayer = player;
        }

        private bool IsThisTheFirstMove()
        {
            return _lastPlayer == null;
        }

        private char GetPlayerMark(Player player)
        {
            return player == _player1
                ? Player1Mark
                : Player2Mark;
        }

        private bool IsPlayer1(Player player)
        {
            return player == _player1;
        }

        private bool IsTheSamePlayerAsInLastMove(Player player)
        {
            return _lastPlayer == player;
        }

        public virtual bool IsDraw()
        {
            return _board.IsBoardFull() && !IsThereAWin();
        }

        public virtual bool IsThereAWin()
        {
            for (int i = 1; i <= 3; i++)
            {
                if (IsWinInRow(i)) return true;
                if (IsWinInColumn(i)) return true;
            }

            if (IsWinInDiagonally()) return true;

            return false;
        }

        private bool IsWinningPattern(string pattern)
        {
            return pattern == Player1Pattern
                || pattern == Player2Pattern;
        }

        private bool IsWinInRow(int rowNumber)
        {
            return IsWinningPattern(_board.GetRow(rowNumber));
        }

        private bool IsWinInColumn(int colNumber)
        {
            return IsWinningPattern(_board.GetColumn(colNumber));
        }

        private bool IsWinInDiagonally()
        {
            return IsWinningPattern(_board.GetAxisLeftBottomToRightTop())
                || IsWinningPattern(_board.GetAxisLeftTopToRightBottm());
        }

        public Player GetWinner()
        {
            return IsThereAWin()
                ? _lastPlayer
                : null;
        }
    }
}