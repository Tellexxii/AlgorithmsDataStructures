using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        LinkedList<T> _items;

        public Deque()
        {
            _items = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            // добавление в голову
            _items.AddFirst(item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            _items.AddLast(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (_items.Count == 0)
            {
                return default(T);
            }

            T item = _items.First.Value;
            _items.RemoveFirst();
            return item;
        }

        public T RemoveTail()
        {
            if (_items.Count == 0)
            {
                return default(T);
            }

            T item = _items.Last.Value;
            _items.RemoveLast();
            return item;
        }

        public int Size()
        {
            return _items.Count; // размер очереди
        }
    }

}