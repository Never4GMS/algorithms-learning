namespace Algorithms.Month01.Les04.Structures
{
    public interface IQueue<T>
    {
        void Enqueue(int priority, T item);

        T Dequeue();

        int Count { get; }
    }
}
