using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;
        

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        private int count;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            count = 0;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                result = string.Compare(v1.ToString().Trim(), v2.ToString().Trim());
            }
            else
            {
                result = Comparer<T>.Default.Compare(v1, v2);
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            // автоматическая вставка value 
            // в нужную позицию
            Node<T> item = new Node<T>(value);

            if (head == null)
            {
                head = item;
                head.next = null;
                head.prev = null;
                tail = item;
            }
            else
            {
                Node<T> current = head;
                bool search = true;
                int asc = _ascending ? 1 : -1;
                int compare;

                
                while (current != null && search)
                {
                    compare = this.Compare(current.value, value);
                    if (compare == asc || compare == 0)
                    {
                        item.prev = current.prev;
                        item.next = current;
                        
                        // Если у текущей ноды нет ссылки на предыдущую, то это голова. Устанавливаем новую ноду в начало
                        if (current.prev == null)
                        {
                            head.prev = item;
                            item.next = head;
                            head = item;
                        }
                        else
                        {
                            current.prev.next = item;
                            current.prev = item;
                        }


                        search = false;
                    }
                    
                    if (search) current = current.next;

                    // Если дошли до конца списка, то делаем элемент хвостом
                    if (current == null)
                    {
                        tail.next = item;
                        item.prev = tail;
                        tail = item;
                    }
                }

            }
            count++;
        }

        public Node<T> Find(T val)
        {

            Node<T> current = head;
            while (current != null)
            {
                if (current.value.Equals(val))
                {
                    return current;
                }

                current = current.next;
            }

            return null;
        }

        public void Delete(T val)
        {
            Node<T> current = Find(val);

            if (current != null)
            {
                if (current.next != null)
                {
                    current.next.prev = current.prev;
                }
                else
                {
                    tail = current.prev;
                }

                if (current.prev != null)
                {
                    current.prev.next = current.next;
                }
                else
                {
                    head = current.next;
                }
                count--;
                
            }

            
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
            count = 0;
        }

        public int Count()
        {
            return count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public List<Node<T>> GetAll() 
            // выдать все элементы упорядоченного 
            // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}