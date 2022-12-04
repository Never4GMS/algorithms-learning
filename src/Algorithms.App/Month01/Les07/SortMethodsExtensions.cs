namespace Algorithms.Month01.Les07
{
    public static class SortMethodsExtensions
    {
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

        public static void Swap<T>(this T[] array, int from, int to)
        {
            var temp = array[to];
            array[to] = array[from];
            array[from] = temp;
        }
    }
}
