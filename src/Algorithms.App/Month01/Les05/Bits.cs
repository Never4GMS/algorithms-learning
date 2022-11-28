namespace Algorithms.Month01.Les05
{
    public static class Bits
    {
        private static ulong[] _cache;

        static Bits()
        {
            _cache = new ulong[256];
            for (var i = 0; i < _cache.Length; i++)
            {
                _cache[i] = PopCount((ulong)i);
            }
        }

        public static ulong PopCount(ulong mask)
        {
            ulong count = 0;
            while (mask > 0)
            {
                mask &= mask - 1;
                count++;
            }

            return count;
        }

        public static ulong PopCountCached(ulong mask)
        {
            ulong count = 0;
            while (mask > 0)
            {
                count += _cache[mask & 255];
                mask >>= 8;
            }

            return count;
        }
    }
}
