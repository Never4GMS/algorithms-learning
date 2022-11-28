namespace Algorithms.Month01.Les05
{
    [Problem(1, 5, "4.Bitboard - Слон")]
    [TestColumn]
    public class ChessMovesBishop : BaseProblemBenchmark<ChessFigurePositionInput, ChessMovesOutput, ulong[]>
    {
        [Benchmark]
        [ArgumentsSource(nameof(Cases))]
        public ulong[] Bishop(ChessFigurePositionInput input, ChessMovesOutput output) =>
            Run(input, output, value =>
            {
                var moves = value.Position.GetBishopMoves();

                return new[] { Bits.PopCount(moves), moves };
            });
    }
}
