namespace Algorithms.Month01.Les05
{
    public static class BitFigures
    {
        public static ulong GetKingMoves(this ushort pos)
        {
            ulong K = 1ul << pos;
            ulong mask =
                BitBoard.Negate.A & (K << 9) | (K << 8) | BitBoard.Negate.H & (K << 7) |
                BitBoard.Negate.A & (K << 1) | BitBoard.Negate.H & (K >> 1) |
                BitBoard.Negate.A & (K >> 7) | (K >> 8) | BitBoard.Negate.H & (K >> 9);

            return mask;
        }

        public static ulong GetKnightMoves(this ushort pos)
        {
            ulong knigiht = 1ul << pos;
            ulong mask = BitBoard.Negate.GH & (knigiht << 6 | knigiht >> 10)
                       | BitBoard.Negate.H & (knigiht << 15 | knigiht >> 17)
                       | BitBoard.Negate.A & (knigiht << 17 | knigiht >> 15)
                       | BitBoard.Negate.AB & (knigiht << 10 | knigiht >> 6);

            return mask;
        }

        public static ulong GetRookMoves(this ushort pos) =>
            (BitBoard.H << (pos % 8) | BitBoard._1 << (pos / 8) * 8) ^ 1ul << pos;

        public static ulong GetBishopMoves(this ushort pos)
        {
            var figure = 1ul << pos;
            ulong moves = 0;

            if ((BitBoard.Slash & figure) == figure)
            {
                moves |= BitBoard.Slash;
            }
            else if ((BitBoard.SlashUpMask & figure) == figure)
            {
                var shift = FindShiftLeft(BitBoard.Slash, figure);

                moves |= (BitBoard.Slash << shift) & BitBoard.SlashUpMask;
            }
            else
            {
                var shift = FindShiftRight(BitBoard.Slash, figure);

                moves |= (BitBoard.Slash >> shift) & BitBoard.SlashDownMask;
            }

            if ((BitBoard.Backslash & figure) == figure)
            {
                moves |= BitBoard.Backslash;
            }
            else if ((BitBoard.BackslashUpMask & figure) == figure)
            {
                var shift = FindShiftRight(BitBoard.Backslash, figure);

                moves |= (BitBoard.Backslash >> shift) & BitBoard.BackslashUpMask;
            }
            else
            {
                var shift = FindShiftLeft(BitBoard.Backslash, figure);

                moves |= (BitBoard.Backslash << shift) & BitBoard.BackslashDownMask;
            }

            return moves ^ figure;
        }

        public static ulong GetQueenMoves(this ushort pos) =>
            GetRookMoves(pos) | GetBishopMoves(pos);

        private static int FindShiftRight(ulong pattern, ulong position)
        {
            var shift = 1;
            for (; ((pattern >> shift) & position) != position; shift++) ;

            return shift;
        }

        private static int FindShiftLeft(ulong pattern, ulong position)
        {
            var shift = 1;
            for (; ((pattern << shift) & position) != position; shift++) ;

            return shift;
        }
    }
}
