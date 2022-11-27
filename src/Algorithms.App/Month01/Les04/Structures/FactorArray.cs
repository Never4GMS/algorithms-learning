namespace Algorithms.Month01.Les04.Structures;

public class FactorArray<T> : BaseArray<T>
{
    private readonly int _factor;

    public FactorArray() : this(50, () => new T[10])
    {
    }

    public FactorArray(int factor) : this(factor, () => new T[factor])
    {
    }

    public FactorArray(T[] values) : this(50, () => values)
    {
        _size = values.Length;
    }

    public FactorArray(int factor, Func<T[]> factory) : base(factory)
    {
        _factor = factor;
    }

    protected override void Resize()
    {
        var array = new T[_array.Length + _array.Length * _factor / 100];
        _array.CopyTo(array, 0);
        _array = array;
    }

    public void UpdateAt(int index, T value)
    {
        _array[index] = value;
    }

    public void AddOrUpdate(int index, T value)
    {
        if (index == _size)
        {
            Add(value);
        }
        else
        {
            UpdateAt(index, value);
        }
    }
}
