using FluentAssertions;
using Moq;
using NUnit.Framework;
using TicTacToe.Exceptions;

namespace TicTacToe.Tests.Unit
{
    [TestFixture]
    public class GameTests
    {
        private Player _player1;
        private Player _player2;
        private Mock<Board> _boardMock;
        private Game _game;
        private Mock<Game> _gameMock;

        [SetUp]
        public void SetUp()
        {
            _player1 = new Player();
            _player2 = new Player();

            _boardMock = new Mock<Board>() { CallBase = true };
            _gameMock = new Mock<Game>(_player1, _player2, _boardMock.Object) { CallBase = true };
            _game = _gameMock.Object;
        }

        [Test]
        public void Player1CanStartTheGame()
        {
            Assert.DoesNotThrow(() => _game.PutMark(_player1, 1, 1));
        }

        [Test]
        public void Player2CannotStartTheGame()
        {
            Assert.Throws<GameException>(() => _game.PutMark(_player2, 1, 1));
        }

        [Test]
        public void Player1CannotMakeTwoPutsConsecutively()
        {
            _game.PutMark(_player1, 1, 1);
            Assert.Throws<InvalidMoveException>(() => _game.PutMark(_player1, 1, 2));
        }

        [Test]
        public void ThereIsADrawWhenBoardIsFullAndThereIsNoWin()
        {
            _boardMock.Setup(x => x.IsBoardFull()).Returns(true);
            _gameMock.Setup(x => x.IsThereAWin()).Returns(false);

            _game.IsDraw().Should().BeTrue();
        }

        [Test]
        public void ThereIsNoDrawWhenBoardIsNotFull()
        {
            _boardMock.Setup(x => x.IsBoardFull()).Returns(false);

            _game.IsDraw().Should().BeFalse();
        }

        [TestCase(
            "XXX" +
            "   " +
            "   ")]
        [TestCase(
            "   " +
            "XXX" +
            "   ")]
        [TestCase(
            "   " +
            "   " + 
            "XXX")]
        [TestCase(
            "X  " +
            "X  " + 
            "X  ")]
        [TestCase(
            " X " +
            " X " + 
            " X ")]
        [TestCase(
            "  X" +
            "  X" + 
            "  X")]
        [TestCase(
            "X  " +
            " X " + 
            "  X")]
        [TestCase(
            "  X" +
            " X " + 
            "X  ")]
        [TestCase(
            "OOO" +
            "   " +
            "   ")]
        [TestCase(
            "   " +
            "OOO" +
            "   ")]
        [TestCase(
            "   " +
            "   " + 
            "OOO")]
        [TestCase(
            "O  " +
            "O  " + 
            "O  ")]
        [TestCase(
            " O " +
            " O " + 
            " O ")]
        [TestCase(
            "  O" +
            "  O" + 
            "  O")]
        [TestCase(
            "O  " +
            " O " + 
            "  O")]
        [TestCase(
            "  O" +
            " O " + 
            "O  ")]
        public void ItIsAWinWhenOnePlayerHasThreeMarksInARowHorizontallyVerticalyOrDiagonally(string boardState)
        {
            var board = TestableBoard.Create(boardState);
            _game = new Game(_player1, _player2, board);

            _game.IsThereAWin().Should().BeTrue();
        }

        [Test]
        public void OnlySpecifiedPlayersAreAllowedToPlay()
        {
            Assert.Throws<GameException>(() => _game.PutMark(new Player(), 1, 1)); 
        }

        [Test]
        public void YouCannotPutMarkWhenGameIsWon()
        {
            _gameMock.Setup(x => x.IsThereAWin()).Returns(true);
            Assert.Throws<GameFinishedException>(() => _game.PutMark(_player1, 1, 1));
        }

        [Test]
        public void YouCannotPutMarkWhenGameIsInADraw()
        {
            _gameMock.Setup(x => x.IsDraw()).Returns(true);
            Assert.Throws<GameFinishedException>(() => _game.PutMark(_player1, 1, 1));
        }
    }
}