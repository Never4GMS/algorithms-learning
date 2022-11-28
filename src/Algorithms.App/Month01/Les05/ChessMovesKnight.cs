namespace Algorithms.Month01.Les05
{
    [Problem(1, 5, "2.Bitboard - Конь")]
    [TestColumn]
    public class ChessMovesKnight : BaseProblemBenchmark<ChessFigurePositionInput, ChessMovesOutput, ulong[]>
    {
        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public ulong[] Knight(ChessFigurePositionInput input, ChessMovesOutput output) =>
            Run(input, output, value =>
            {
                var moves = value.Position.GetKnightMoves();

                return new[] { Bits.PopCount(moves), moves };
            });
    }
}
