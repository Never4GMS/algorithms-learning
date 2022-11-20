namespace Algorithms.Month01.Les04.Structures;

public class MatrixArray<T> : IArray<T>
{
    private int _size;
    private readonly int _vector;
    private readonly SingleArray<VectorArray<T>> _array;

    public MatrixArray() : this(10)
    {
    }

    public MatrixArray(T[] values) : this(10)
    {
        foreach (var value in values)
        {
            Add(value);
        }
    }

    public MatrixArray(int vector)
    {
        _vector = vector;
        _array = new SingleArray<VectorArray<T>>();
        _size = 0;
    }

    public void Add(T item)
    {
        if (_size >= _array.Size() * _vector)
        {
            _array.Add(new VectorArray<T>(_vector));
        }

        _array.Get(_size / _vector).Add(item);
        _size++;
    }

    public void Add(T item, int index)
    {
        Add(Get(_size - 1));
        for (var i = _size - 2; i > index; i--)
        {
            UpdateAt(i, Get(i - 1));
        }
        UpdateAt(index, item);
    }

    private void UpdateAt(int index, T item)
    {
        _array.Get(index / _vector).UpdateAt(index % _vector, item);
    }

    public T Get(int index) => _array.Get(index / _vector).Get(index % _vector);

    public T Remove(int index)
    {
        var value = Get(index);
        for (var i = index; i < _size - 1; i++)
        {
            UpdateAt(i, Get(i + 1));
        }
        _size--;

        return value;
    }

    public int Size() => _size;

    public T[] ToArray()
    {
        var array = new T[_size];
        for (var i = 0; i < _size; i++)
        {
            array[i] = Get(i);
        }
        return array;
    }
}
