using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private LinkedList<T> _items;

        public Stack()
        {
            _items = new LinkedList<T>();
        }

        public int Size()
        {
            // размер текущего стека		  
            return _items.Count;
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                return default(T);
            }

            T result = _items.Last.Value;
            _items.RemoveLast();

            return result;
            
        }

        public void Push(T val)
        {
            _items.AddLast(val);
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                return default(T);
            }
            return _items.Last.Value;
        }
    }

}