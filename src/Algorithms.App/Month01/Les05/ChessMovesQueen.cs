namespace Algorithms.Month01.Les05
{
    [Problem(1, 5, "5.Bitboard - Ферзь")]
    [TestColumn]
    public class ChessMovesQueen : BaseProblemBenchmark<ChessFigurePositionInput, ChessMovesOutput, ulong[]>
    {
        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public ulong[] Queen(ChessFigurePositionInput input, ChessMovesOutput output) =>
            Run(input, output, value =>
            {
                var moves = value.Position.GetQueenMoves();

                return new[] { Bits.PopCount(moves), moves };
            });
    }
}
