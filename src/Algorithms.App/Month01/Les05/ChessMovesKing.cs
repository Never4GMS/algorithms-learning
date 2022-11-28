namespace Algorithms.Month01.Les05
{
    // https://gekomad.github.io/Cinnamon/BitboardCalculator/
    [Problem(1, 5, "1.Bitboard - Король")]
    [TestColumn]
    public class ChessMovesKing : BaseProblemBenchmark<ChessFigurePositionInput, ChessMovesOutput, ulong[]>
    {
        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public ulong[] King(ChessFigurePositionInput input, ChessMovesOutput output) =>
            Run(input, output, value =>
            {
                var moves = value.Position.GetKingMoves();

                return new[] { Bits.PopCount(moves), moves };
            });
    }
}
