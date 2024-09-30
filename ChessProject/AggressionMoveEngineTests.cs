using NUnit.Framework;
using Xunit;
using Xunit.Abstractions;

namespace ChessProject
{
    public class AggressionMoveEngineTests
    {
        private ITestOutputHelper _output { get; }

        public AggressionMoveEngineTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Xunit.Theory]
        [InlineData("p")]
        [InlineData("k")]
        [InlineData("q")]
        [InlineData("r")]
        [InlineData("b")]
        [InlineData("n")]
        public void AllMovesAreContainedInBoard(string fenString)
        {
            var startFenString = "8/8/8/3";
            var endFenString = "4/8/8/8 b - - 0 1";
            var totalFenString = startFenString + fenString + endFenString;
            var board = FENParser.FenStringToBoard(totalFenString);

            var moves = AggressionMoveEngine.GetAggressionPieceMoves(board, 27);


            Assert.That(moves.Min() >= 0 && moves.Max() < 64);
        }

    }
}
