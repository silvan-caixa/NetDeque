namespace NetDeque
{
    public class Deque<T>
    {
        private LinkedList<T> _data = new();

        public int Count => _data.Count;
        public bool IsEmpty => Count == 0;

        public void AddBeg(T item)
            => _data.AddFirst(item);

        public void AddEnd(T item)
            => _data.AddLast(item);

        public T RemBeg()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Deque is empty.");

            T item = _data!.First!.Value;

            _data.RemoveFirst();
            return item;
        }

        public T RemEnd()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Deque is empty.");

            T item = _data!.Last!.Value;

            _data.RemoveLast();
            return item;
        }

        public T PeekBeg()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Deque is empty.");

            return _data!.First!.Value;
        }

        public T PeekEnd()
        {
            if (_data.Count == 0)
                throw new InvalidOperationException("Deque is empty.");

            return _data!.Last!.Value;
        }
    }
}
