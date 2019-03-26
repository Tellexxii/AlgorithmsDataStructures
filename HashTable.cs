using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int index = Math.Abs(value.GetHashCode()) % size;
            return index;
            //return 0;
        }

        public int SeekSlot(string value)
        {
            int index = this.HashFun(value);

            if (slots[index] != null)
            {
                int firtsEnter = index;
                while (slots[index] != null)
                {
                    index = (index + step) % size;
                    if (index == firtsEnter) return -1;
                }

                return index;
            }

            return index;

        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            int index = this.SeekSlot(value);
            if (index != -1)
            {
                slots[index] = value;
                return index;
            }
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            return -1;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
           
            int index = this.HashFun(value);
            //int index = this.SeekSlot(value);
            if (slots[index] == value) return index;
            else
            {
                int firtsEnter = index;
                while (slots[index] != value)
                {
                    index = (index + step) % size;
                    if (index == firtsEnter) return -1;
                }

                return index;
            }
        }
    }

}