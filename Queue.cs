using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private LinkedList<T> _items;

        public Queue()
        {
            // инициализация внутреннего хранилища очереди
            _items = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            // вставка в хвост
            _items.AddFirst(item);
        }

        public T Dequeue()
        {
            // выдача из головы
            if (_items.Count == 0)
            {
                return default(T);
            }

            T last = _items.Last.Value;
            _items.RemoveLast();
            
            return last;
        }

        public int Size()
        {
            return _items.Count; // размер очереди
        }

    }
}