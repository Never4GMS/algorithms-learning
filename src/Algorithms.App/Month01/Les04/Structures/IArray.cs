namespace Algorithms.Month01.Les04.Structures;

public interface IArray<T>
{
    int Size();

    void Add(T item);

    T Get(int index);

    void Add(T item, int index);

    T Remove(int index);

    T[] ToArray();
}
