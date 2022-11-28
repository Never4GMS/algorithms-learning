namespace Algorithms.Month01.Les05
{
    [Problem(1, 5, "3.Bitboard - Ладья")]
    [TestColumn]
    public class ChessMovesRook : BaseProblemBenchmark<ChessFigurePositionInput, ChessMovesOutput, ulong[]>
    {
        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public ulong[] Rook(ChessFigurePositionInput input, ChessMovesOutput output) =>
            Run(input, output, value =>
            {
                var moves = value.Position.GetRookMoves();

                return new[] { Bits.PopCount(moves), moves };
            });
    }
}
