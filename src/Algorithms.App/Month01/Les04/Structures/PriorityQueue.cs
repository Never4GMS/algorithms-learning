namespace Algorithms.Month01.Les04.Structures
{
    public class PriorityQueue<T> : IQueue<T>
    {
        private readonly LinkedList<Node> _priorities = new();

        private int _count = 0;

        public int Count => _count;

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var queue = _priorities.Last.Value.Queue;
            var value = queue.Last;
            queue.RemoveLast();
            if (queue.Count == 0)
            {
                _priorities.RemoveLast();
            }
            _count--;

            return value.Value;
        }

        public void Enqueue(int priority, T item)
        {
            var current = _priorities.First;
            LinkedListNode<Node> min = null;
            var diff = int.MinValue;
            var added = false;
            while (current != null)
            {
                if (current.Value.Priority == priority)
                {
                    current.Value.Queue.AddFirst(item);
                    added = true;
                    break;
                }

                var currentDiff = current.Value.Priority - priority;
                if (currentDiff < 0 && currentDiff > diff)
                {
                    min = current;
                    diff = currentDiff;
                }

                current = current.Next;
            }

            if (!added)
            {
                var node = new Node { Priority = priority, Queue = new LinkedList<T>() };
                node.Queue.AddFirst(item);

                if (min == null)
                {
                    _priorities.AddFirst(node);
                }
                else
                {
                    _priorities.AddAfter(min, node);
                }
            }

            _count++;
        }

        private class Node : IEquatable<Node>
        {
            public int Priority { get; set; }

            public LinkedList<T> Queue { get; set; }

            public bool Equals(PriorityQueue<T>.Node? other)
            {
                return Priority == other.Priority;
            }
        }
    }
}
