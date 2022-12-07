namespace Algorithms.Sorting
{
    public static class SortMethodsExtensions
    {
        public static void SetRandom(this int[] array)
        {
            var random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, int.MaxValue);
            }
        }

        public static void BubbleSort<T>(this T[] array) where T : IComparable<T>
        {
            var span = array.AsSpan();
            var n = span.Length;

            for (var j = n - 1; j >= 0; j--)
            {
                for (var i = 0; i < j; i++)
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

            for (var j = 1; j < n; j++)
            {
                for (var i = j - 1; i >= 0 && span[i].CompareTo(span[i + 1]) > 0; i--)
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

        public static void SelectSort<T>(this T[] array) where T : IComparable<T>
        {
            var n = array.Length;

            for (int j = n - 1; j > 0; j--)
            {
                array.Swap(array.FindMax(j), j);
            }
        }

        public static void HeapSort<T>(this T[] array) where T : IComparable<T>
        {
            var n = array.Length;

            for (int h = n / 2 - 1; h >= 0; h--)
            {
                array.Heapify(h, n);
            }

            for (int j = n - 1; j > 0; j--)
            {
                array.Swap(0, j);
                array.Heapify(0, j);
            }
        }

        public static void Heapify<T>(this T[] array, int root, int size) where T : IComparable<T>
        {
            int X = root;
            int L = 2 * X + 1;
            int R = L + 1;
            if (L < size && array[L].CompareTo(array[X]) > 0) X = L;
            if (R < size && array[R].CompareTo(array[X]) > 0) X = R;
            if (X == root) return;

            array.Swap(root, X);
            array.Heapify(X, size);
        }

        public static int FindMax<T>(this T[] array, int j) where T : IComparable<T>
        {
            var max = j;
            do
            {
                if (array[max].CompareTo(array[j]) < 0)
                {
                    max = j;
                }
            }
            while (--j >= 0);

            return max;
        }

        public static void QuickSort<T>(this T[] array, Comparer<T> comparer = null) where T : IComparable<T>
        {
            comparer ??= Comparer<T>.Default;
            QuickSortRecursion(array.AsSpan(), comparer);
        }

        private static void QuickSortRecursion<T>(this Span<T> span, Comparer<T> comparer)
        {
            if (span.IsEmpty) return;

            var pivot = GetPivot(span, comparer);
            QuickSortRecursion(span[..pivot], comparer);
            QuickSortRecursion(span[(pivot + 1)..], comparer);
        }

        private static int GetPivot<T>(Span<T> span, Comparer<T> comparer)
        {
            var pivotIndex = span.Length - 1;
            var pivotValue = span[pivotIndex];
            var wallIndex = pivotIndex;

            for (var i = 0; i <= pivotIndex; i++)
            {
                if (comparer.Compare(span[i], pivotValue) <= 0)
                {
                    span.Swap(i, wallIndex);
                    wallIndex++;
                }
            }

            span.Swap(wallIndex, pivotIndex);

            return wallIndex;
        }

        public static void MeargeSort<T>(this T[] array, Comparer<T> comparer = null) where T : IComparable<T>
        {
            var n = array.Length;
            comparer ??= Comparer<T>.Default;
        }

        public static void Swap<T>(this T[] array, int from, int to)
        {
            var temp = array[to];
            array[to] = array[from];
            array[from] = temp;
        }

        public static void Swap<T>(this Span<T> span, int from, int to)
        {
            (span[to], span[from]) = (span[from], span[to]);
        }
    }
}
