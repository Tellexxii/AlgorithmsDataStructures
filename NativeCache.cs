using System;
using System.Collections.Generic;
using System.Security;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;
        public int capacity;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            capacity = 0;
        }

        public int HashFun(string key)
        {
            int index = Math.Abs(key.GetHashCode()) % size;
            return index;
        }

        public bool IsKey(string key)
        {
            int hash_index = this.HashFun(key);
            if (capacity != size)
            {
                return slots[this.HashFun(key)] != null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (slots[(hash_index + i) % size].Equals(key))
                    {
                        return true;
                    }
                }

                return false;
            }
            

        }

        public void Put(string key, T value)
        {
            int index = this.HashFun(key);
            if (hits[index] == 0)
            {
                hits[index] = hits[index] + 1;
                slots[index] = key;
                values[index] = value;
                capacity++;
            }
            else
            {
                if (capacity == size)
                {
                    int lowerHitNum = hits[0];
                    int hit_index = 0;
                    for (int i = 1; i < size; i++)
                    {
                        if (hits[i] < lowerHitNum)
                        {
                            lowerHitNum = hits[i];
                            hit_index = i;
                        }
                    }

                    hits[hit_index] = 1;
                    slots[hit_index] = key;
                    values[hit_index] = value;
                }
                else
                {
                    hits[index] = hits[index] + 1;
                    slots[index] = key;
                    values[index] = value;
                }
            }
        }

        public T Get(string key)
        {
            //return this.IsKey(key) ? values[this.HashFun(key)] : default(T); int hash_index = this.HashFun(key);
            if (IsKey(key))
            {
                int hash_index = this.HashFun(key);
                if (capacity != size)
                {
                    return values[this.HashFun(key)];
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (slots[(hash_index + i) % size].Equals(key))
                        {
                            return values[(hash_index + i) % size];
                        }
                    }

                    return default(T);

                }
            }
            else
            {
                return default(T);
            }
        }

    }
}