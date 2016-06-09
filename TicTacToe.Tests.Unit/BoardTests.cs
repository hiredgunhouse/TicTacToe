using FluentAssertions;
using NUnit.Framework;
using TicTacToe.Exceptions;

namespace TicTacToe.Tests.Unit
{
    [TestFixture]
    public class BoardTests
    {
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
        }

        [TestCase('X', 1, 1)]
        [TestCase('X', 1, 2)]
        [TestCase('X', 1, 3)]
        [TestCase('X', 2, 1)]
        [TestCase('X', 2, 2)]
        [TestCase('X', 2, 3)]
        [TestCase('X', 3, 1)]
        [TestCase('X', 3, 2)]
        [TestCase('X', 3, 3)]
        [TestCase('O', 1, 1)]
        [TestCase('O', 1, 2)]
        [TestCase('O', 1, 3)]
        [TestCase('O', 2, 1)]
        [TestCase('O', 2, 2)]
        [TestCase('O', 2, 3)]
        [TestCase('O', 3, 1)]
        [TestCase('O', 3, 2)]
        [TestCase('O', 3, 3)]
        public void YouCanPutMarkOnAPositionThatIsNotAlreadyTaken(char mark, int x, int y)
        {
            Assert.DoesNotThrow(() => _board.PutMark(mark, x, y));
        }

        [TestCase(0, 1)]
        [TestCase(4, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 4)]
        public void YouCannotPutMarkOnAPositionThatIsOutsideBoardBoundaries(int x, int y)
        {
            Assert.Throws<PositionOutsideBoardBoundariesException>(() => _board.PutMark('X', x, y));
        }

        [TestCase('X', 1, 1)]
        [TestCase('X', 1, 2)]
        [TestCase('X', 1, 3)]
        [TestCase('X', 2, 1)]
        [TestCase('X', 2, 2)]
        [TestCase('X', 2, 3)]
        [TestCase('X', 3, 1)]
        [TestCase('X', 3, 2)]
        [TestCase('X', 3, 3)]
        [TestCase('O', 1, 1)]
        [TestCase('O', 1, 2)]
        [TestCase('O', 1, 3)]
        [TestCase('O', 2, 1)]
        [TestCase('O', 2, 2)]
        [TestCase('O', 2, 3)]
        [TestCase('O', 3, 1)]
        [TestCase('O', 3, 2)]
        [TestCase('O', 3, 3)]
        public void YouCannotPutMarkOnAPositionThatIsAlreadyTaken(char mark, int x, int y)
        {
            _board.PutMark(mark, x, y);
            Assert.Throws<PositionTakenException>(() => _board.PutMark(mark, x, y));
        }

        [TestCase(
            "XXX" +
            "XXX" + 
            "XXX")]
        [TestCase(
            "OOO" +
            "OOO" + 
            "OOO")]
        public void WhenAllPositionsAreTakenBoardIsReportedToBeFull(string boardState)
        {
            _board = TestableBoard.Create(boardState);
            _board.IsBoardFull().Should().BeTrue();
        }

        [TestCase(
            " XX" +
            "XXX" + 
            "XXX")]
        [TestCase(
            "X X" +
            "XXX" + 
            "XXX")]
        [TestCase(
            "XX " +
            "XXX" + 
            "XXX")]
        [TestCase(
            "XXX" +
            " XX" + 
            "XXX")]
        [TestCase(
            "XXX" +
            "X X" + 
            "XXX")]
        [TestCase(
            "XXX" +
            "XX " + 
            "XXX")]
        [TestCase(
            "XXX" +
            "XXX" + 
            " XX")]
        [TestCase(
            "XXX" +
            "XXX" + 
            "X X")]
        [TestCase(
            "XXX" +
            "XXX" + 
            "XX ")]
        [TestCase(
            " OO" +
            "OOO" + 
            "OOO")]
        [TestCase(
            "O O" +
            "OOO" + 
            "OOO")]
        [TestCase(
            "OO " +
            "OOO" + 
            "OOO")]
        [TestCase(
            "OOO" +
            " OO" + 
            "OOO")]
        [TestCase(
            "OOO" +
            "O O" + 
            "OOO")]
        [TestCase(
            "OOO" +
            "OO " + 
            "OOO")]
        [TestCase(
            "OOO" +
            "OOO" + 
            " OO")]
        [TestCase(
            "OOO" +
            "OOO" + 
            "O O")]
        [TestCase(
            "OOO" +
            "OOO" + 
            "OO ")]
        public void WhenNotAllPositionsAreTakenBoardIsReportedToNotBeFull(string boardState)
        {
            _board = TestableBoard.Create(boardState);
            _board.IsBoardFull().Should().BeFalse();
        }
    }
}