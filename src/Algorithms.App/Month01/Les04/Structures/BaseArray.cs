namespace Algorithms.Month01.Les04.Structures;

public abstract class BaseArray<T> : IArray<T>
{
    protected int _size = 0;
    protected T[] _array;

    public BaseArray(Func<T[]> factory)
    {
        _array = factory();
    }

    public void Add(T item)
    {
        if (_size >= _array.Length)
        {
            Resize();
        }
        _array[_size++] = item;
    }

    protected abstract void Resize();

    public virtual void Add(T item, int index)
    {
        if (_size >= _array.Length)
        {
            Resize();
        }

        ShiftRightFrom(index);
        _array[index] = item;
        _size++;
    }

    public T Get(int index) => index < _size
        ? _array[index]
        : throw new ArgumentOutOfRangeException(nameof(index));

    public virtual T Remove(int index)
    {
        var value = Get(index);
        ShiftLeftTo(index);
        _size--;
        return value;
    }

    public int Size() => _size;

    public T[] ToArray()
    {
        var array = new T[_size];
        _array.AsSpan(0, _size).CopyTo(array);
        return array;
    }

    protected void ShiftRightFrom(int index)
    {
        for (var i = _size; i > index; i--)
        {
            _array[i] = _array[i - 1];
        }
    }

    protected void ShiftLeftTo(int index)
    {
        for (var i = index; i < _size - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
    }
}
