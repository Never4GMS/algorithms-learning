namespace Algorithms.Month01.Les04.Structures;

public class SingleArray<T> : BaseArray<T>
{
    public SingleArray() : base(() => new T[0])
    {
    }

    public SingleArray(T[] values) : base(() => values)
    {
        _size = values.Length;
    }

    protected override void Resize()
    {
        var array = new T[_array.Length + 1];
        _array.CopyTo(array, 0);
        _array = array;
    }
}
