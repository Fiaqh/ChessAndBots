using ChessProject;
using System;
using Xunit.Abstractions;

namespace ChessProjectTests
{
    public class AggressionMoveEngineTests
    {
        private ITestOutputHelper _output { get; }

        public AggressionMoveEngineTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Theory]
        [InlineData("p")]
        [InlineData("k")]
        [InlineData("q")]
        [InlineData("r")]
        [InlineData("b")]
        [InlineData("n")]
        public void AllMovesAreContainedInBoard(string pieceChar)
        {
            var startFenString = "8/8/8/3";
            var endFenString = "4/8/8/8/8 b - - 0 1";
            var totalFenString = startFenString + pieceChar + endFenString;
            var board = FENParser.FenStringToBoard(totalFenString);

            var moves = AggressionMoveEngine.GetAggressionPieceMoves(board, 27);


            Assert.True(moves.Min() >= 0 && moves.Max() < 64);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(7)]
        public void BackboardCantMoveAtStartExcludingKnightBlackStart(int index)
        {
            var startFenStringBlackStart = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR b KQkq - 0 1";
            var board = FENParser.FenStringToBoard(startFenStringBlackStart);

            var moves = AggressionMoveEngine.GetAggressionPieceMoves(board, index);


            Assert.True(moves.Count() == 0);
        }

        [Theory]
        [InlineData(56)]
        [InlineData(58)]
        [InlineData(59)]
        [InlineData(60)]
        [InlineData(61)]
        [InlineData(63)]
        public void BackboardCantMoveAtStartExcludingKnightWhiteStart(int index)
        {
            var startFenStringBlackStart = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            var board = FENParser.FenStringToBoard(startFenStringBlackStart);

            var moves = AggressionMoveEngine.GetAggressionPieceMoves(board, index);


            Assert.True(moves.Count() == 0);
        }

        [Fact]
        public void EnPassantShouldBeInMoves()
        {
            var startFenString = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq c3 0 1";
            var board = FENParser.FenStringToBoard(startFenString);
            var moves = AggressionMoveEngine.GetAggressionPieceMoves(board, 49);
            var EnPassantMove = FENParser.AlgebraicNotationToIndex("c3");

            Assert.Contains(42, moves);

        }

    }
}
