namespace Algorithms.Month01.Les04.Structures;

public class VectorArray<T> : BaseArray<T>
{
    private readonly int _vector;

    public VectorArray(int vector) : this(vector, () => new T[vector])
    {
    }

    public VectorArray(T[] values) : this(10, () => values)
    {
        _size = values.Length;
    }

    public VectorArray(int vector, Func<T[]> factory) : base(factory)
    {
        _vector = vector;
    }

    protected override void Resize()
    {
        var array = new T[_size + _vector];
        _array.CopyTo(array, 0);
        _array = array;
    }

    public void UpdateAt(int index, T value)
    {
        _array[index] = value;
    }
}
