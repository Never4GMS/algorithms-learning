namespace Algorithms.Month01.Les04.Structures;

public class WrappedArray<T> : List<T>, IArray<T>
{
    public WrappedArray(T[] array) : base(array)
    {
    }

    public void Add(T item, int index) => Insert(index, item);

    public T Get(int index) => this[index];

    public T Remove(int index)
    {
        var value = this[index];
        RemoveAt(index);
        return value;
    }

    public int Size() => Count;
}
