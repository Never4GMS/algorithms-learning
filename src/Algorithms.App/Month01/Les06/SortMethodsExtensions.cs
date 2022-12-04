namespace Algorithms.Month01.Les06
{
    public static class SortMethodsExtensions
    {
        public static void SetRandom(this uint[] array)
        {
            var random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = (uint)random.Next(0, int.MaxValue);
            }
        }

        public static void BubbleSort<T>(this T[] array) where T : IComparable<T>
        {
            var span = array.AsSpan();
            var n = span.Length;

            for (int j = n - 1; j >= 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (span[i].CompareTo(span[i + 1]) > 0)
                    {
                        span.Swap(i, i + 1);
                    }
                }
            }
        }

        public static void InsertionSort<T>(this T[] array) where T : IComparable<T>
        {
            var span = array.AsSpan();
            var n = span.Length;

            for (int j = 1; j < n; j++)
            {
                for (int i = j - 1; i >= 0 && span[i].CompareTo(span[i + 1]) > 0; i--)
                {
                    span.Swap(i, i + 1);
                }
            }
        }

        public static void InsertionShiftSort<T>(this T[] array) where T : IComparable<T>
        {
            var span = array.AsSpan();
            var n = span.Length;

            for (var j = 1; j < n; j++)
            {
                var k = span[j];
                int i;
                for (i = j - 1; i >= 0 && span[i].CompareTo(k) > 0; i--)
                {
                    span[i + 1] = span[i];
                }

                span[i + 1] = k;
            }
        }

        public static void InsertionBinarySort<T>(this T[] array) where T : IComparable<T>
        {
            var span = array.AsSpan();
            var n = span.Length;

            for (var j = 1; j < n; j++)
            {
                var k = span[j];
                var p = span.BinarySearch(k, 0, j - 1);

                int i;
                for (i = j - 1; i >= p; i--)
                {
                    span[i + 1] = span[i];
                }
                span[i + 1] = k;
            }
        }

        private static int BinarySearch<T>(this Span<T> span, T key, int low, int high) where T : IComparable<T>
        {
            if (high <= low)
            {
                if (key.CompareTo(span[low]) > 0)
                {
                    return low + 1;
                }
                else
                {
                    return low;
                }
            }

            var mid = (low + high) / 2;
            if (key.CompareTo(span[mid]) > 0)
            {
                return span.BinarySearch(key, mid + 1, high);
            }
            else
            {
                return span.BinarySearch(key, low, mid - 1);
            }
        }

        public static void ShellSort<T>(this T[] array) where T : IComparable<T>
        {
            var span = array.AsSpan();
            var n = span.Length;

            for (var gap = n / 2; gap > 0; gap /= 2)
            {
                for (var i = gap; i < n; i++)
                {
                    for (var j = i; j > gap && span[j - gap].CompareTo(span[j]) > 0; j -= gap)
                    {
                        span.Swap(j - gap, j);
                    }
                }
            }
        }

        public static void Swap<T>(this Span<T> span, int from, int to)
        {
            (span[to], span[from]) = (span[from], span[to]);
        }
    }
}
